import Counter from "./Components/Counter";
import FetchDelete from "./Components/FetchDelete";
import Filter from "./Components/Filter";
import Quotes from "./Components/Quotes";
import "./index.css";

function App() {
  return (
    <div className="font-mono flex flex-wrap flex-col h-screen bg-gray-300">
      <div className="flex flex-none h-72 w-screen justify-evenly items-center ">
        <FetchDelete></FetchDelete>

        <Filter></Filter>

        <Counter></Counter>
      </div>
      <div className="pt-5 flex flex-row flex-1 bg-gray-200 overflow-y-auto">
        <Quotes></Quotes>
      </div>
    </div>
  );
}

export default App;
