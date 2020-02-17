SET IDENTITY_INSERT [dbo].[Course] ON
INSERT INTO [dbo].[Course] ([Id], [CourseName], [Description], [Duration], [Price]) VALUES (1, N'Web Programming with C#', N'Build your own production grade web application ', 7, CAST(100.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Course] ([Id], [CourseName], [Description], [Duration], [Price]) VALUES (2, N'Advanced Microservices ', N'Microservices development in the cloud ', 14, CAST(200.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[Instructor] ON
INSERT INTO [dbo].[Instructor] ([Id], [Name], [Email]) VALUES (1, N'Jake Wilton', N'jake@courses.com')
INSERT INTO [dbo].[Instructor] ([Id], [Name], [Email]) VALUES (2, N'Mike  Knight ', N'mike@courses.com')
SET IDENTITY_INSERT [dbo].[Instructor] OFF
SET IDENTITY_INSERT [dbo].[Student] ON
INSERT INTO [dbo].[Student] ([Id], [Name], [Email]) VALUES (1, N'William Turner', N'william@courses.com')
INSERT INTO [dbo].[Student] ([Id], [Name], [Email]) VALUES (2, N'Leonardo Evans', N'leonardo@courses.com')
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[Enrollment] ON
INSERT INTO [dbo].[Enrollment] ([Id], [CourseId], [InstructorId], [StudentId]) VALUES (1, 1, 1, 1)
INSERT INTO [dbo].[Enrollment] ([Id], [CourseId], [InstructorId], [StudentId]) VALUES (2, 2, 2, 2)
SET IDENTITY_INSERT [dbo].[Enrollment] OFF
