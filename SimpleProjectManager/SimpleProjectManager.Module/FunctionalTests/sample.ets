;#DropDB SimpleProjectManagerEasyTest

#Application SimpleProjectManagerWin
#Application SimpleProjectManagerWeb
#IfDef SimpleProjectManagerWin

*Action About...
 
*Action OK

#EndIf

#IfDef SimpleProjectManagerWeb
!Action Navigation(My Details)
#EndIf
