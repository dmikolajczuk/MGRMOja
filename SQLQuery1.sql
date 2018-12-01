SELECT Sum(o.Sum),o.Id_User,Date FROM Orders o
GROUP BY o.Date, o.Id_User;