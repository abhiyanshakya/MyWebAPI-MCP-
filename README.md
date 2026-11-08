# MyWebAPI-MCP-

reference - https://www.youtube.com/watch?v=38GNKtclDdE

NOTE - Your Books table has an Id column that SQL Server generates automatically (Identity column). We cannot post a new Id manually that needs to be changed. If for instance we deleted id = 1 then if we want to Post a new object with id = 1 then we cannot do that with the code we have at the moment, we need to change our code in a way we can add a object with it's id manually and if the id already exist then there must be a exception handling in place.