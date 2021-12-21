import { useContext, useEffect } from "react";
import { AppContext } from "./app-context";
const useQuotes = () => {
  const [state, setState] = useContext(AppContext);

  useEffect(() => {
    filterQuotes();
  }, [state.quotes, state.filterAmount]);

  const changeValue = (e) => {
    if (e.target.value >= 1) {
      setState({ ...state, filterAmount: e.target.value });
    }
  };
  const loadQuote = async () => {
    let response = await fetch("https://api.kanye.rest/");
    let result = await response.json();
    let new_quotes = [...state.quotes, result.quote];
    setState({ ...state, quotes: new_quotes });
  };
  const deleteQuote = (q) => {
    let new_quotes = state.quotes.filter((quote) => {
      return !(q === quote);
    });
    setState({ ...state, quotes: new_quotes });
  };

  const deleteQuotes = () => {
    setState({ ...state, quotes: [] });
  };
  const filterQuotes = () => {
    let quotes = state.quotes;
    let newQuotes = [];
    let wordCount = 1;
    for (let i = 0; i < quotes.length; i++) {
      const currentWord = quotes[i];
      for (let j = 0; j < quotes[i].length; j++) {
        const currentChar = currentWord.charAt(j);
        if (currentChar === " ") {
          wordCount++;
        }
      }
      if (wordCount >= state.filterAmount) {
        newQuotes.push(currentWord);
      }
      wordCount = 1;
    }
    setState({ ...state, filteredQuotes: newQuotes });
  };

  return {
    filterAmount: state.filterAmount,
    changeValue,
    deleteQuote,
    loadQuote,
    deleteQuotes,
    filteredQuotes: state.filteredQuotes,
    quotes: state.quotes,
    totalQamount: state.quotes.length,
    totalFamount: state.filteredQuotes.length,
  };
};

export default useQuotes;
