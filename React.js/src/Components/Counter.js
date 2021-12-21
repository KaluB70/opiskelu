import useQuotes from "../UseQuotes";

function Counter() {
  const { totalQamount, totalFamount } = useQuotes();
  return (
    <div className="flex flex-col space-y-6">
      <h3 className="text-3xl">
        Total quote count: <b>{totalQamount}</b>
      </h3>
      <h3 className="text-3xl">
        Quotes in view: <b>{totalFamount}</b>
      </h3>
    </div>
  );
}

export default Counter;
