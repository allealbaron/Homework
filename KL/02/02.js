// Returns true if the difference between t1.time and t2.time
// is less or equal than 60 seconds
function lessThanAMinute(t1,t2)
{
  
  const t1Date = new Date(t1.time);
  const t2Date = new Date(t2.time);  
  const difference = Math.abs(t1Date - t2Date);

  return ((Math.round(difference/1000))<= 60) ;

}

// Returns if two transactions are duplicated
function areDuplicatedTransactions(t1, t2)
{
  
  const compareFirst = compareCommon(t1,t2);
  
  if (compareFirst != 0)
  {
    return false;
  }
 
  return (lessThanAMinute(t1,t2));

}

/// Compares two items by sourceAccount, targetAccount,
/// category and amount
function compareCommon(t1, t2)
{
  
   if (t1.sourceAccount < t2.sourceAccount)
    {
      return -1;
    }

    if (t1.sourceAccount > t2.sourceAccount)
    {
      return 1;
    }

    if (t1.targetAccount < t2.targetAccount)
    {
      return -1;
    }

    if (t1.targetAccount > t2.targetAccount)
    {
      return 1;
    }

    if (t1.category < t2.category)
    {
      return -1;
    }

    if (t1.category > t2.category)
    {
      return 1;
    }

    if (t1.amount < t2.amount)
    {
      return -1;
    }

    if (t1.amount > t2.amount)
    {
      return 1;
    }
  
    return 0;  
  
}

/// Compares transactions first by date
/// (Useful to sort transactions
function compareTransactionsByDate(t1, t2)
{
  
  const t1Date = new Date(t1.time);
  const t2Date = new Date(t2.time);  

  if (t1Date < t2Date)
  {
    return -1;
  }

  if (t1Date > t2Date)
  {
    return 1;
  }
  
  const compareFirst = compareCommon(t1,t2);    
  
  if (compareFirst != 0)
  {
    return compareFirst;
  }
  
  if (t1.id < t2.id)
  {
    return -1;
  }

  if (t1.id > t2.id)
  {
    return 1;
  } 

  return 0;
  
}

/// Given a list of transactions, returns duplicated items
/// Two items are duplicated if they have same sourceAccount,
/// targetAccount, category, amount and the difference between
/// their dates is less than 60 seconds
/// returns list of duplicated items sorted by date
function findDuplicates (transactions = []) {
  
    let result = [];
    
    /// In this set we store items already detected as duplicated items
    /// Since transactions are going to be sorted by date, we could have
    /// situations where two duplicated transactions are 'interweaved'
    let addedIds = new Set();
  
    transactions.sort(compareTransactionsByDate);  
  
    let i = 0;
    let j = 1;
    
    let subResult = [];      
    subResult.push(transactions[i]);
  
    while (i < transactions.length) 
    {
      
      let t1 = transactions[i];      
      let t2 = transactions[j];
        
      while (j < transactions.length && areDuplicatedTransactions(t1,t2))       
      {
        subResult.push(t2);
        j++;
        t1 = t2;
        t2 = transactions[j];        
      }      

      if (j < transactions.length && lessThanAMinute(t1,t2))
      {
        /// 'interweaved' transactions
        j++;
      }      
      else
      {          
        if (subResult.length>1)
        {
          for (var k=0; k<subResult.length; k++)
          {
              addedIds.add(subResult[k].id);
          }
          result.push(subResult);
        }

        subResult = [];

        i++;

        // We avoid transactions already detected as duplicated
        while (i<transactions.length && addedIds.has(transactions[i].id))
        {
          i++;
        }          

        if (i < transactions.length)
        {
          subResult.push(transactions[i]);
          j = i + 1;
        }           
        
      }
    }
    
    return result;      
  
}    