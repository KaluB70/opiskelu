import React from "react";
import useQuotes from "../UseQuotes";

function Filter() {
  const { changeValue, filterAmount } = useQuotes();
  const changeV = (e) => {
    changeValue(e);
  };
  return (
    <div className="flex flex-col justify-items-center items-center space-y-6">
      <h1 className="font-bold text-6xl">Kanye oneliners</h1>
      <h3 className="font-bold text-3xl">Word count filter:</h3>
      <input
        className="w-1/6 h-12 text-3xl rounded-lg shadow-lg selection:border-2"
        type="number"
        value={filterAmount}
        onChange={changeV}
      ></input>
    </div>
  );
}

export default Filter;
