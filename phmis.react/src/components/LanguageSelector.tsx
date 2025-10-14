import { useLanguage } from '../contexts/LanguageContext';
import './LanguageSelector.css';

const LanguageSelector = () => {
  const { currentLanguage, availableLanguages, setLanguage } = useLanguage();

  return (
    <div className="language-selector">
      <select 
        value={currentLanguage} 
        onChange={(e) => setLanguage(e.target.value)}
        className="language-select"
      >
        {availableLanguages.map((lang) => (
          <option key={lang.code} value={lang.code}>
            {lang.name}
          </option>
        ))}
      </select>
    </div>
  );
};

export default LanguageSelector;