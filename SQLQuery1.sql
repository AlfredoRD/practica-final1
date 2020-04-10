CREATE TRIGGER Triggerl
ON [dbo] . [AspNetUserRoles]
For UPDate
AS
UPDATE AspNetUserRoles
Set RoleId = '1' where RolesName =  'Administrador'
UPDATE AspNetUserRoles
Set RoleId = '2' where RolesName =  'Usuario'
UPDATE AspNetUserRoles
Set RoleId = '3' where RolesName =  'Seguridad'
UPDATE AspNetUserRoles
Set RoleId = '4' where RolesName =  'Gestion'