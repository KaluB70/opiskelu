import React from "react";
import useQuotes from "../UseQuotes";

function Fetch_Delete() {
  const { loadQuote, deleteQuotes } = useQuotes();

  return (
    <div className="flex flex-col space-y-12">
      <button
        className="text-2xl h-16 bg-gray-100 hover:bg-green-500 text-green-700 font-semibold
         hover:text-white py-2 px-4 border border-green-500 hover:border-transparent rounded-lg shadow-lg"
        onClick={loadQuote}
      >
        Fetch 1 quote
      </button>
      <button
        className="text-2xl h-16 w-72 bg-red-500 hover:bg-red-900 text-white font-bold py-2 px-4 rounded-lg shadow-lg"
        onClick={deleteQuotes}
      >
        Delete all quotes
      </button>
    </div>
  );
}

export default Fetch_Delete;
