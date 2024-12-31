export default function StockItem({
  action,
  name,
  price,
  totalQuantity,
  availableQuantity,
  id,
}) {
  return (
    <div className="flex flex-row justify-between border-b-2 p-2 items-center">
      <div className="">{name}</div>
      <div className="flex flex-row text-end items-center">
        <div className="flex flex-col">
          <div>{`Rs ${price}`}</div>
          <div>{`${availableQuantity}(${totalQuantity})`}</div>
        </div>
        {action && <div className="ml-10">{action}</div>}
      </div>
    </div>
  );
}
