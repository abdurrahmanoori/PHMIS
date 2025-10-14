import { useState, useEffect } from 'react';
import { useLanguage } from '../contexts/LanguageContext';

interface ProvinceTranslation {
    id: number;
    provinceId: number;
    languageCode: string;
    languageId: number;
    isDefault: boolean;
    name: string;
}

interface UseTranslationsReturn {
    translations: ProvinceTranslation[];
    loading: boolean;
    error: string | null;
    fetchTranslations: (provinceId: number) => Promise<void>;
    addTranslation: (translation: Omit<ProvinceTranslation, 'id'>) => Promise<void>;
    updateTranslation: (id: number, translation: Partial<ProvinceTranslation>) => Promise<void>;
    deleteTranslation: (id: number) => Promise<void>;
}

export const useTranslations = (): UseTranslationsReturn => {
    const [translations, setTranslations] = useState<ProvinceTranslation[]>([]);
    const [loading, setLoading] = useState<boolean>(false);
    const [error, setError] = useState<string | null>(null);
    const { currentLanguage } = useLanguage();

    const fetchTranslations = async (provinceId: number) => {
        setLoading(true);
        setError(null);
        try {
            const response = await fetch(`/api/provincetranslation/province/${provinceId}`);
            if (!response.ok) {
                throw new Error(`Error fetching translations: ${response.status}`);
            }
            const data = await response.json();
            setTranslations(data);
        } catch (err) {
            setError(err instanceof Error ? err.message : 'Failed to fetch translations');
        } finally {
            setLoading(false);
        }
    };

    const addTranslation = async (translation: Omit<ProvinceTranslation, 'id'>) => {
        setLoading(true);
        try {
            const response = await fetch('/api/provincetranslation', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(translation),
            });
            if (!response.ok) {
                throw new Error(`Error adding translation: ${response.status}`);
            }
            const newTranslation = await response.json();
            setTranslations(prev => [...prev, newTranslation]);
        } catch (err) {
            setError(err instanceof Error ? err.message : 'Failed to add translation');
        } finally {
            setLoading(false);
        }
    };

    const updateTranslation = async (id: number, translation: Partial<ProvinceTranslation>) => {
        setLoading(true);
        try {
            const response = await fetch(`/api/provincetranslation/${id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(translation),
            });
            if (!response.ok) {
                throw new Error(`Error updating translation: ${response.status}`);
            }
            const updatedTranslation = await response.json();
            setTranslations(prev => prev.map(t => t.id === id ? updatedTranslation : t));
        } catch (err) {
            setError(err instanceof Error ? err.message : 'Failed to update translation');
        } finally {
            setLoading(false);
        }
    };

    const deleteTranslation = async (id: number) => {
        setLoading(true);
        try {
            const response = await fetch(`/api/provincetranslation/${id}`, {
                method: 'DELETE',
            });
            if (!response.ok) {
                throw new Error(`Error deleting translation: ${response.status}`);
            }
            setTranslations(prev => prev.filter(t => t.id !== id));
        } catch (err) {
            setError(err instanceof Error ? err.message : 'Failed to delete translation');
        } finally {
            setLoading(false);
        }
    };

    return {
        translations,
        loading,
        error,
        fetchTranslations,
        addTranslation,
        updateTranslation,
        deleteTranslation,
    };
};