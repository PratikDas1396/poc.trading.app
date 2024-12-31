export default function Table({ columnDefs, data, onRowClick }) {
  return (
    <table class="border-collapse  table-auto w-full">
      <thead>
        <tr>
          {columnDefs?.map((col, ind) => (
            <th key={`table-heading-${ind}`} className="p-2 border text-left">
              {col.title}
            </th>
          ))}
        </tr>
      </thead>
      <tbody>
        {data?.map((item, ind) => (
          <tr
            key={`table-row-${ind}`}
            className={`${
              onRowClick ? "cursor-pointer hover:bg-slate-50" : ""
            }`}
            onClick={() => onRowClick?.(item)}>
            {columnDefs?.map((col, colInd) => (
              <td
                key={`table-data-${colInd}`}
                className={`p-2 border text-${col.align ?? "left"} 
                w-${col.width ?? "auto"}`}>
                {col?.cellRenderer ? col.cellRenderer(item) : item[col.field]}
              </td>
            ))}
          </tr>
        ))}
      </tbody>
    </table>
  );
}
