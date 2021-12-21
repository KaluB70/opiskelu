import { createContext, useState } from "react";

const AppContext = createContext([{}, () => {}]);

const AppProvider = ({ children }) => {
  let quotes = [];

  const [state, setState] = useState({
    quotes: quotes,
    filteredQuotes: quotes,
    filterAmount: 1,
    totalQamount: 0,
    totalFamount: 0,
  });

  return (
    <AppContext.Provider value={[state, setState]}>
      {children}
    </AppContext.Provider>
  );
};

export { AppContext, AppProvider };
