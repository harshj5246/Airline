SET IDENTITY_INSERT [dbo].[Booking] ON
INSERT INTO [dbo].[Booking] ([ticket_id], [flight_id], [UserName], [Airline_name], [source], [destination], [Total_Amount], [Class], [Date], [No_Of_Tickets]) VALUES (100009, N'101', N'hj5246', N'jet', N'rjy', N'bza', CAST(7000.0000 AS Money), N'System.Windows.Controls.ComboBoxItem: Economy ', N'20-09-2022', 2)
INSERT INTO [dbo].[Booking] ([ticket_id], [flight_id], [UserName], [Airline_name], [source], [destination], [Total_Amount], [Class], [Date], [No_Of_Tickets]) VALUES (100013, N'102', N'hj5246', N'jet', N'rjy', N'bza', CAST(22500.0000 AS Money), N'System.Windows.Controls.ComboBoxItem: Business', N'20-09-2022', 5)
SET IDENTITY_INSERT [dbo].[Booking] OFF
