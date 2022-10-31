const ListComponent = (props) => {
  if (
    props.data === undefined ||
    props.data === null ||
    props.data.length === 0
  ) {
    return (
      <div className="container">
        <strong>No Data to Display</strong>
      </div>
    );
  } else {
    return props.data.map((e, index) => (
      <tr>
        {Object.keys(e).map((header, index) => {
          if (header !== "IsAdmitted") return <td>{e[header]}</td>;
          else {
            return <td>{e[header].toString()}</td>;
          }
        })}
      </tr>
    ));
  }
};

export default ListComponent;
