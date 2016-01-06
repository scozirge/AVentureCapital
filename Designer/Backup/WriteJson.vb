Sub  髒字表()
	'建立物件並設定路徑位置
	Dim SystemFileObj As Object
	Set SystemFileObj = CreateFileSysteme()
	MyFileFolder=GetParentFolderName(SystemFileObj, "髒字表Json.xls")
	resFolder=SystemFileObj.GetParentFolderName(MyFileFolder)
	FileName = resFolder & "\strings\dirty.json"
	'建立文字檔，並設定為可以複寫
	Set JsonFileName=SystemFileObj.CreateTextFile(FileName,True,True)

	result= procTableCell(JsonFileName,0,0,0,0)
	result = procTable(JsonFileName, "髒字")
	result = procTableCell(JsonFileName, 2, 0, 0, 0)
    JsonFileName.Close
	
	'跳出是否成功輸出Json
    bOK = True
    If bOK = False Then
        result = MsgBox(ErrorMsg, vbOKOnly, "錯誤訊息", "", 0)
    Else
        sTitle = "髒字資訊"
        sPrompt = "輸出髒字資訊成功" & vbNewLine & File & vbNewLine & FileName & vbNewLine & FileExp
        result = MsgBox(sPrompt, vbOKOnly, sTitle, "", 0)
    End If
End Sub



'建立物件
Function CreateFileSysteme() As Object
    Set CreateFileSysteme = CreateObject("Scripting.FileSystemObject")
End Function

'寫入Jason文字格式
Function procTableCell(JsonFileObj, writeMode, tabNo, cellData, cellName) As Boolean
    If writeMode = 0 Then
                JsonFileObj.write("{""Dirty"":[" )
    ElseIf writeMode = 1 Then
                JsonFileObj.write(String(tabNo, vbTab) & """" & cellName & """:""" & cellData & """")
    ElseIf writeMode = 2 Then
                JsonFileObj.write(Chr(10) &"]}")
    End If
End Function
'寫入表單內容
Function procTable(JsonFileObjName, sheet) As Boolean
    With Worksheets(sheet)
    y = 3
    x = 1
    ID = .Cells(y, x)
    While ID <> "End"
        If ID <> "" And ID <> "Skip" Then
			result = JsonFileObjName.write(Chr(10) & String(1, vbTab))
            result = procTableColumn(JsonFileObjName, sheet, y, 2)			
        End If
		y = y + 1
		NextID=.Cells(y, x)
		While NextID = "" And NextID = "Skip"
				y = y + 1
				NextID=.Cells(y, x)
		Wend
		If NextID <> "End" And NextID <> "Skip" AND NextID <> "" Then
			result =JsonFileObjName.write(",")
		End If
        ID = NextID
    Wend
    End With
End Function

Function procTableColumn(JsonFileObj, sheet, y, columnNo) As Boolean
    With Worksheets(sheet)
    x = 1
	cellName=.Cells(1,x)
    While cellName <> ""
			If x =1 Then
				result = JsonFileObj.write("{")
			End If
			cellData = checkColumnEmpty(.Cells(y, x), "None")
            result = procTableCell(JsonFileObj, 1, 1, cellData, cellName)
			x = x + 1
			nextCellName=.Cells(1,x)
			If nextCellName <> "" Then
				result = JsonFileObj.write(",")
			Else
				result = JsonFileObj.write("}")
			End If
			cellName=nextCellName
    Wend
    End With
End Function

Function checkColumnEmpty(column, defaultValue) As String
    If column = "" Then
        checkColumnEmpty = defaultValue
    Else
        checkColumnEmpty = column
    End If
End Function

Function GetParentFolderName(SystmeFileObj As Object, FileName As String) As String
    GetParentFolderName = ""
    '檢查c到z磁碟機
    For driverNo = 99 To 122
        SearchPath = Chr(driverNo) & ":" & FileName
        findFilePath = SystmeFileObj.GetAbsolutePathName(SearchPath)
        If (SystmeFileObj.FileExists(findFilePath)) Then
          GetParentFolderName = SystmeFileObj.GetParentFolderName(findFilePath)
          GoTo found
        End If
    Next driverNo
found:
End Function
