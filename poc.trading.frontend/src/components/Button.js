export default function Button({ name, className, disabled }) {
  return (
    <button
      disabled={disabled}
      className={`rounded-full bg-green-500 px-2 py-1 text-white ${
        className ?? ""
      }`}>
      {name}
    </button>
  );
}
