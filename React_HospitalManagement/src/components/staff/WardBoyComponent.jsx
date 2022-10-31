const WardBoyComponent = (props) => {
    return (
      <form>
        <div className='control-group'>
          <div className='form-control'>
            <label htmlFor='name'>WardBoy Id</label>
            <input type='number' id='name' />
          </div>
          <div className='form-control'>
            <label htmlFor='name'>Name</label>
            <input type='text' id='name' />
          </div>
        </div>
        <div className='form-control'>
          <label htmlFor='name'>E-Mail Address</label>
          <input type='text' id='name' />
        </div>
        <div className='form-control'>
          <label htmlFor='name'>Number</label>
          <input type='number' id='name' />
        </div>
        <div className='form-actions'>
          <button>Add</button>
        </div>
      </form>
    );
  };
  
  export default WardBoyComponent;