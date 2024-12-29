export default function StockItem({ action }) {
  return (
    <div className="flex flex-row justify-between border-b-2 p-2 items-center">
      <div className="">Name</div>
      <div className="flex flex-row text-end items-center">
        <div className="flex flex-col">
          <div>Rs 400</div>
          <div>-20.00(-2.69)</div>
        </div>
        {action && <div className="ml-10">{action}</div>}
      </div>
    </div>
  );
}
