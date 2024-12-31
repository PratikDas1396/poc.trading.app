export function Button({ name, className, disabled, onClick }) {
  return (
    <button
      disabled={disabled}
      className={`rounded-full bg-green-500 px-2 py-1 text-white disabled:bg-slate-300 ${
        className ?? ""
      }`}
      onClick={onClick}>
      {name}
    </button>
  );
}

export function LinkButton({ name, className, disabled, onClick }) {
  return (
    <button
      disabled={disabled}
      className={`rounded-full text-green-500 px-2 py-1 disabled:bg-slate-300 ${
        className ?? ""
      }`}
      onClick={onClick}>
      {name}
    </button>
  );
}
