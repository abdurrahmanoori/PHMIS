import { useState, useEffect } from 'react';
import { useLanguage } from '../contexts/LanguageContext';
import { useTranslations } from '../hooks/useTranslations';

interface Province {
  id: number;
  name: string; // This will be the default language name
}

export default function Provinces() {
  const [provinces, setProvinces] = useState<Province[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);
  const { currentLanguage } = useLanguage();
  const { translations, fetchTranslations } = useTranslations();
  const [selectedProvince, setSelectedProvince] = useState<Province | null>(null);
  const [showTranslationModal, setShowTranslationModal] = useState<boolean>(false);
 const [newTranslation, setNewTranslation] = useState({
    name: '',
    languageCode: currentLanguage,
    provinceId: 0,
    languageId: 1, // Default to English
    isDefault: false
  });

  // Fetch provinces from the API
  useEffect(() => {
    const fetchProvinces = async () => {
      try {
        const response = await fetch('/api/province');
        if (!response.ok) {
          throw new Error(`Error fetching provinces: ${response.status}`);
        }
        const data = await response.json();
        setProvinces(data.items || data); // Handle both paginated and non-paginated responses
        setLoading(false);
      } catch (err) {
        setError(err instanceof Error ? err.message : 'Failed to fetch provinces');
        setLoading(false);
      }
    };

    fetchProvinces();
  }, []);

  // Fetch translations when a province is selected
  useEffect(() => {
    if (selectedProvince) {
      fetchTranslations(selectedProvince.id);
    }
  }, [selectedProvince, fetchTranslations]);

  // Get translated name for a province based on current language
  const getTranslatedName = (provinceId: number): string => {
    // Find translation for current language
    const translation = translations.find(t => t.provinceId === provinceId && t.languageCode === currentLanguage);
    
    // If no translation exists for current language, return default translation or original name
    if (translation) {
      return translation.name;
    }
    
    // Look for a default translation
    const defaultTranslation = translations.find(t => t.provinceId === provinceId && t.isDefault);
    if (defaultTranslation) {
      return defaultTranslation.name;
    }
    
    // Fallback to the original province name
    const originalProvince = provinces.find(p => p.id === provinceId);
    return originalProvince ? originalProvince.name : `Province ${provinceId}`;
  };

  const handleAddTranslation = () => {
    if (selectedProvince) {
      setNewTranslation({
        ...newTranslation,
        provinceId: selectedProvince.id,
        languageCode: currentLanguage
      });
      setShowTranslationModal(true);
    }
  };

  const handleSubmitTranslation = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      // In a real app, we would need to determine the languageId from the languageCode
      // For now, we'll use a simple mapping or default to 1 (English)
      const languageIdMap: Record<string, number> = { 'en': 1, 'ps': 2, 'fa': 3 };
      const languageId = languageIdMap[newTranslation.languageCode] || 1;
      
      await fetch('/api/provincetranslation', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          ...newTranslation,
          languageId: languageId
        }),
      });
      
      // Refresh translations
      if (selectedProvince) {
        await fetchTranslations(selectedProvince.id);
      }
      
      setShowTranslationModal(false);
      setNewTranslation({
        name: '',
        languageCode: currentLanguage,
        provinceId: 0,
        languageId: 1,
        isDefault: false
      });
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Failed to add translation');
    }
  };

  if (loading) {
    return (
      <div className="page">
        <div className="page-header">
          <h1 className="page-title">Provinces</h1>
          <button className="primary-button" disabled>Loading...</button>
        </div>
        <div className="panel">
          <div className="panel-header">
            <h2>All Provinces</h2>
            <input className="search" placeholder="Search provinces…" disabled />
          </div>
          <div className="loading">Loading provinces...</div>
        </div>
      </div>
    );
  }

  if (error) {
    return (
      <div className="page">
        <div className="page-header">
          <h1 className="page-title">Provinces</h1>
          <button className="primary-button">New Province</button>
        </div>
        <div className="panel">
          <div className="panel-header">
            <h2>All Provinces</h2>
          </div>
          <div className="error">Error: {error}</div>
        </div>
      </div>
    );
  }

  return (
    <div className="page">
      <div className="page-header">
        <h1 className="page-title">Provinces</h1>
        <button className="primary-button">New Province</button>
      </div>
      <div className="panel">
        <div className="panel-header">
          <h2>All Provinces</h2>
          <input className="search" placeholder="Search provinces…" />
        </div>
        
        <div className="provinces-list">
          {provinces.length > 0 ? (
            provinces.map(province => (
              <div
                key={province.id}
                className={`province-item ${selectedProvince?.id === province.id ? 'selected' : ''}`}
                onClick={() => setSelectedProvince(province)}
              >
                <div className="province-name">
                  {getTranslatedName(province.id)}
                </div>
                <div className="province-id">ID: {province.id}</div>
              </div>
            ))
          ) : (
            <div className="empty">No provinces found.</div>
          )}
        </div>
      </div>

      {selectedProvince && (
        <div className="panel">
          <div className="panel-header">
            <h2>Translations for {selectedProvince.name}</h2>
            <button className="primary-button" onClick={handleAddTranslation}>
              Add Translation
            </button>
          </div>
          
          <div className="translations-list">
            {translations.length > 0 ? (
              translations
                .filter(t => t.provinceId === selectedProvince.id)
                .map(translation => (
                  <div key={translation.id} className="translation-item">
                    <div className="translation-language">
                      <strong>{translation.languageCode.toUpperCase()}:</strong> {translation.name}
                    </div>
                    <div className="translation-actions">
                      <button
                        className="secondary-button small"
                        onClick={async () => {
                          // Toggle default status
                          try {
                            await fetch(`/api/provincetranslation/${translation.id}`, {
                              method: 'PUT',
                              headers: {
                                'Content-Type': 'application/json',
                              },
                              body: JSON.stringify({
                                ...translation,
                                isDefault: !translation.isDefault
                              }),
                            });
                            // Refresh translations
                            await fetchTranslations(selectedProvince.id);
                          } catch (err) {
                            setError(err instanceof Error ? err.message : 'Failed to update translation');
                          }
                        }}
                      >
                        {translation.isDefault ? 'Unset Default' : 'Set Default'}
                      </button>
                      <button
                        className="danger-button small"
                        onClick={async () => {
                          if (window.confirm('Are you sure you want to delete this translation?')) {
                            try {
                              await fetch(`/api/provincetranslation/${translation.id}`, {
                                method: 'DELETE',
                              });
                              // Refresh translations
                              await fetchTranslations(selectedProvince.id);
                            } catch (err) {
                              setError(err instanceof Error ? err.message : 'Failed to delete translation');
                            }
                          }
                        }}
                      >
                        Delete
                      </button>
                    </div>
                  </div>
                ))
            ) : (
              <div className="empty">No translations available for this province.</div>
            )}
          </div>
        </div>
      )}

      {/* Translation Modal */}
      {showTranslationModal && (
        <div className="modal-overlay" onClick={() => setShowTranslationModal(false)}>
          <div className="modal-content" onClick={(e) => e.stopPropagation()}>
            <h3>Add Translation</h3>
            <form onSubmit={handleSubmitTranslation}>
              <div className="form-group">
                <label htmlFor="language">Language:</label>
                <select
                  id="language"
                  value={newTranslation.languageCode}
                  onChange={(e) => setNewTranslation({
                    ...newTranslation,
                    languageCode: e.target.value,
                    languageId: e.target.value === 'en' ? 1 : e.target.value === 'ps' ? 2 : 3
                  })}
                  className="form-control"
                >
                  <option value="en">English</option>
                  <option value="ps">Pashto</option>
                  <option value="fa">Farsi</option>
                </select>
              </div>
              <div className="form-group">
                <label htmlFor="name">Translated Name:</label>
                <input
                  type="text"
                  id="name"
                  value={newTranslation.name}
                  onChange={(e) => setNewTranslation({...newTranslation, name: e.target.value})}
                  className="form-control"
                  required
                />
              </div>
              <div className="form-group">
                <label>
                  <input
                    type="checkbox"
                    checked={newTranslation.isDefault}
                    onChange={(e) => setNewTranslation({...newTranslation, isDefault: e.target.checked})}
                  />
                  Set as default translation
                </label>
              </div>
              <div className="form-actions">
                <button type="button" className="secondary-button" onClick={() => setShowTranslationModal(false)}>
                  Cancel
                </button>
                <button type="submit" className="primary-button">
                  Add Translation
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  );
}
