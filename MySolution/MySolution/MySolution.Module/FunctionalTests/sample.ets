;#DropDB MySolutionEasyTest

#Application MySolutionWin
#Application MySolutionWeb
#IfDef MySolutionWin

*Action About...
 
*Action OK

#EndIf

#IfDef MySolutionWeb
*Action Navigation(My Details)
#EndIf
