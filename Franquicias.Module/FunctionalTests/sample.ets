;#DropDB FranquiciasEasyTest

#Application FranquiciasWin
#Application FranquiciasWeb

*FillForm
 User Name = Admin
*Action Log In

#IfDef FranquiciasWin

*Action About...
 
*Action OK

#EndIf

#IfDef FranquiciasWeb
*Action Navigation(My Details)
#EndIf
