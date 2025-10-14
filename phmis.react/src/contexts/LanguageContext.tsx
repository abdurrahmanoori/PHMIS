import React, { createContext, useContext, useState } from 'react';
import type { ReactNode } from 'react';

interface LanguageContextType {
  currentLanguage: string;
 availableLanguages: { code: string; name: string }[];
  setLanguage: (langCode: string) => void;
}

const LanguageContext = createContext<LanguageContextType | undefined>(undefined);

export const LanguageProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [currentLanguage, setCurrentLanguage] = useState<string>('en');
  
  const availableLanguages = [
    { code: 'en', name: 'English' },
    { code: 'ps', name: 'Pashto' },
    { code: 'fa', name: 'Farsi' },
  ];

  const setLanguage = (langCode: string) => {
    setCurrentLanguage(langCode);
    localStorage.setItem('language', langCode);
  };

  // Initialize language from localStorage or default to 'en'
  React.useEffect(() => {
    const savedLanguage = localStorage.getItem('language');
    if (savedLanguage && availableLanguages.some(lang => lang.code === savedLanguage)) {
      setCurrentLanguage(savedLanguage);
    }
  }, []);

  return (
    <LanguageContext.Provider value={{ currentLanguage, availableLanguages, setLanguage }}>
      {children}
    </LanguageContext.Provider>
  );
};

export const useLanguage = () => {
 const context = useContext(LanguageContext);
  if (!context) {
    throw new Error('useLanguage must be used within a LanguageProvider');
  }
  return context;
};