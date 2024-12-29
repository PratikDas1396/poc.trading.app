import Button from "../../components/Button";

export default function Order() {
  return (
    <div className="border-2 border-gray-50 border-solid rounded-md">
      <div className="border-b-2 p-3">
        <div>stock name</div>
        <div>price</div>
      </div>
      <div className="p-3 h-[300px]">
        <div className="flex justify-between mb-2">
          <span>Qty:</span>
          <input type="number" className="border-2" />
        </div>
        <div className="flex justify-between">
          <span>Price:</span>
          <input type="number" className="border-2" />
        </div>
      </div>
      <div className="border-t-2 p-3">
        <Button name="Buy" className={"w-full"} />
      </div>
    </div>
  );
}
