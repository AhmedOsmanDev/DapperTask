Task Details :-

Database Tables : -

Order        > id, date, totalprice(sum of orderDetails totalprice), itemcount, userid,insertdate

OrderDetails > id, itemname, price, quantity, totalprice, orderid, insertdate

user         > id , name , email , address

APIs :-

- Get All Orders (id , date , total , itemcount ,userid ,user name, insertdate) with orderDetails list

- Get Order by id (id , date , total , itemcount ,userid ,user name, insertdate) with orderDetails list

- Add Order with orderDetails list

- Update order with orderDetails list

- delete Order with orderDetails list

Note :-   project structure (Repository Pattern)
Note :-   Don't forget comments.
Note :-   Don't forget sql script for database creation
Note :-   work on sql server
