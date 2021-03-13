import React from "react";

class UniqueList extends React.Component {

  // Component constructor
  constructor(props) {
    super(props);
    
      this.state = {
      currentValue: '',
      itemsList: []
    }
    
  }
  
  // Triggered when item-input changes its value
  onInputChange = (e) => {
      
    this.setState({
      currentValue: e.target.value
    });

  }
  
  // Triggered when in item-input a key is pressed
  onInputKeyDown = (e) => {
    
    if (e.key === 'Enter') {
      this.onAddClick();
    }
    
  }

  // Triggered when add-button is clicked
  onAddClick = () => {
    
    const {currentValue, itemsList} = this.state;
  
    const position = itemsList.indexOf(currentValue.trim());
    
    let newInputValue = currentValue;
    
    if (newInputValue.trim() != '' && position == -1)
    {
      itemsList.push(newInputValue.trim());
      newInputValue = '';
    }
    
    this.setState({
                  currentValue: newInputValue,
                   itemsList:itemsList
                });
    
  }
  
  // Triggered when remove-button is clicked
  onRemoveClick = () => {
    
    const {currentValue, itemsList} = this.state;        
    
    const position = itemsList.indexOf(currentValue.trim());
    
    if (position>-1)
    {
      itemsList.splice(position,1);
      this.setState({
                      currentValue: '',
                       itemsList:itemsList
                    });
    }
    
  }
  
  // Triggered when clear-button is clicked
   onClearClick = () => {
     
    const {currentValue, itemsList} = this.state;
     
    let newInputValue = currentValue;
     
    if (itemsList.length>0)
    {
      newInputValue = '';
    }
    
       this.setState( {
        currentValue: newInputValue,
        itemsList: []
      });
     
    }
    
  render() {
    
    const {currentValue, itemsList} = this.state;
    
    return (
      <>
        <div>
          <label
            className="label-input"
            htmlFor="inputField"
          >
            Item
          </label>
          <input
            id ="inputField"
            className="item-input"
            type="text"
            title="Please write the item you want to add/delete. System will trim white spaces after and before"
            value={currentValue}
            onChange={this.onInputChange}
            onKeyDown={this.onInputKeyDown}
          />
          <input
            className="add-button"
            type="button"
            value="Add Item"
            title="Adds an item (doesn't allow duplicates)"
            onClick={this.onAddClick}
          />
          <input
            className="remove-button"
            type="button"
            value="Remove Item"
            title="Removes the input if existing in the list"
            onClick={this.onRemoveClick}
          />
          <input
            className="clear-button"
            type="button"
            value="Clear Items"
            title="Clears the list"
            onClick={this.onClearClick}
          />
        </div>
        <ul className="items">
          {
            itemsList.map(item => (
          <li key={item}>{item}</li>
             ) ) }
        </ul>
      </>
    );
  }
}

export default UniqueList;