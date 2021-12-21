import Quote from "./Quote";
import useQuotes from "../UseQuotes";

const Quotes = () => {
  const { filteredQuotes, totalFamount } = useQuotes();
  if (totalFamount > 0) {
    return (
      <div className="w-full flex flex-row">
        <div className="flex flex-col text-2xl w-3/4 ml-4 space-y-4">
          {filteredQuotes.map((quote, index) => {
            return <Quote key={quote + index} quote={quote}></Quote>;
          })}
        </div>
        <div className="ml-8 relative md:">
          <img
            className="w-1/5 rounded-lg shadow-lg fixed overflow-hidden"
            src="http://fashionbombdaily.com/wp-content/uploads/2020/04/Kanye-West-Is-Now-Officially-A-Billionaire-According-To-Forbes-.jpg"
            alt="Kanye"
          />
        </div>
      </div>
    );
  } else {
    return (
      <div className="flex flex-col text-2xl ml-4 w-1/2">
        <p>No quotes!</p>
      </div>
    );
  }
};

export default Quotes;
