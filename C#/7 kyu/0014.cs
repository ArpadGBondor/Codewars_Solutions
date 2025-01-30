// Kata: FIXME: Get Full Name
// Link: https://www.codewars.com/kata/597c684822bc9388f600010f

// The code provided is supposed return a person's Full Name given their first
// and last names.

// But it's not working properly.

// Notes
// The first and/or last names are never null, but may be empty.

// Task
// Fix the bug so we can all go home early.

public class Dinglemouse
{
  private string firstName;
  private string lastName;
  public string FullName
  {
    get
    {
      return $"{firstName}{((firstName.Length > 0 && lastName.Length > 0) ? " " : "")}{lastName}";
    }
  }
  
  public Dinglemouse(string _firstName, string _lastName)
  {
    firstName = _firstName;
    lastName = _lastName;
  }
}