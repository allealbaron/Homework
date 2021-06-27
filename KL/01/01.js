function getBalanceInPeriodByCategory (transactions = [], category, start, end) {
  
    // Asssuming start and end are valid timestamps, and each transaction 
    // is a correct transaction containing all its items  
    // We only cast start and end one time instead of creating a new Date object in every loop
    const startDate = new Date(start);
    const endDate = new Date(end);
    
    let result = 0;
    
    // We only add amount's value if it is a number and also the category is
    // the same as the category parameter and its date (time) is between start and end
    // Date shall be >= start and < end (not <=)  
    for(var i = 0; i < transactions.length; i++) 
    {
        
      const transaction = transactions[i];    
      
      if (transaction.category == category && 
          (!isNaN(transaction.amount)) && 
          (startDate<= new Date(transaction.time)) && 
          (endDate > new Date(transaction.time)) )      
          {
            result += transaction.amount;
          }    
    }
    
    return result;

}
    