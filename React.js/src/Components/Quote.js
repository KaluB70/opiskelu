import React from "react";
import useQuotes from "../UseQuotes";

const Quote = ({ quote }) => {
  const { deleteQuote } = useQuotes();

  const deleteClick = () => {
    deleteQuote(quote);
  };

  return (
    <div className="flex flex-row justify-between items-center bg-gray-100 p-4 rounded-lg shadow-lg">
      {quote}
      <button
        onClick={deleteClick}
        className="max-h-12 bg-red-500 hover:bg-red-800 text-white font-bold py-2 px-4 rounded-lg self-center shadow-lg"
        type="submit"
      >
        Delete
      </button>
    </div>
  );
};

export default Quote;
