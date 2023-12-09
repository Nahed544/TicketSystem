# TicketSystem 
5- Tickets will be automatically marked as handled if it was created within 60 minutes
I Created a new job in SQL Server with this script 
   UPDATE Tickets
    SET IsHandled = 1
    WHERE IsHandled = 0
    AND CreationDateTime < DATEADD(MINUTE, -60, GETDATE());
