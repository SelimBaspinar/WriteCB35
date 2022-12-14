Module Module1

        'VB.NET Module
        'Producer: SelimBaspinar
        'Pointer/Offset Coding

        'Read Sample Coding;
        ' Me.Text = ReadPointerInteger(Game's Task Manager Name, &HPointer,&HOffset).ToString()
        ' Me.Text = ReadPointerInteger("ac_client", &HB71A38,&H540).ToString()
        ' If There Are More Than One OffSet (Write From Large to Small)
        ' In other words, the first offset will be at the end, and the next offset will be the previous offset.

        'Sample Coding;
        ' Me.Text = ReadPointerInteger("ac_client", &HB71A38,&H14,&H0).ToString()
        ' If Offset is 3 Pieces;;
        ' Me.Text = ReadPointerInteger("ac_client", &HB71A38,&H378,&H14,&H0).ToString()

        'Write Sample Coding
        ' WritePointerInteger(Game's Task Manager Name,&HPointer,Value(Deger),&HOffset)
        ' WritePointerInteger("ac_client",&HB71A38,1000,&H540)
        ' Or(If Offset is More than One)
        ' WritePointerInteger("gta_sa",&HB71A38,1000,&H378, &H14,&H0)









        Private Declare Function ReadMemoryByte Lib "kernel32" Alias "ReadProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Byte, Optional ByVal Size As Integer = 2, Optional ByRef Bytes As Integer = 0) As Byte
        Private Declare Function ReadMemoryInteger Lib "kernel32" Alias "ReadProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Integer, Optional ByVal Size As Integer = 4, Optional ByRef Bytes As Integer = 0) As Integer
        Private Declare Function ReadMemoryFloat Lib "kernel32" Alias "ReadProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Single, Optional ByVal Size As Integer = 4, Optional ByRef Bytes As Integer = 0) As Single
        Private Declare Function ReadMemoryDouble Lib "kernel32" Alias "ReadProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Double, Optional ByVal Size As Integer = 8, Optional ByRef Bytes As Integer = 0) As Double

        Private Declare Function WriteMemoryByte Lib "kernel32" Alias "WriteProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Byte, Optional ByVal Size As Integer = 2, Optional ByRef Bytes As Integer = 0) As Byte
        Private Declare Function WriteMemoryInteger Lib "kernel32" Alias "WriteProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Integer, Optional ByVal Size As Integer = 4, Optional ByRef Bytes As Integer = 0) As Integer
        Private Declare Function WriteMemoryFloat Lib "kernel32" Alias "WriteProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Single, Optional ByVal Size As Integer = 2, Optional ByRef Bytes As Integer = 0) As Single
        Private Declare Function WriteMemoryDouble Lib "kernel32" Alias "WriteProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Double, Optional ByVal Size As Integer = 2, Optional ByRef Bytes As Integer = 0) As Double

        Public Function ReadByte(ByVal EXENAME As String, ByVal Address As Integer) As Byte
            Dim Value As Byte
            If Process.GetProcessesByName(EXENAME).Length <> 0 Then
                Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
                If Handle <> 0 Then
                    ReadMemoryByte(Handle, Address, Value)
                End If
            End If
            Return Value
        End Function

        Public Function ReadInteger(ByVal EXENAME As String, ByVal Address As Integer) As Integer
            Dim Value As Integer
            If Process.GetProcessesByName(EXENAME).Length <> 0 Then
                Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
                If Handle <> 0 Then
                    ReadMemoryInteger(Handle, Address, Value)
                End If
            End If
            Return Value
        End Function

        Public Function ReadFloat(ByVal EXENAME As String, ByVal Address As Integer) As Single
            Dim Value As Single
            If Process.GetProcessesByName(EXENAME).Length <> 0 Then
                Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
                If Handle <> 0 Then
                    ReadMemoryFloat(Handle, Address, Value)
                End If
            End If
            Return Value
        End Function

        Public Function ReadDouble(ByVal EXENAME As String, ByVal Address As Integer) As Double
            Dim Value As Double
            If Process.GetProcessesByName(EXENAME).Length <> 0 Then
                Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
                If Handle <> 0 Then
                    ReadMemoryByte(Handle, Address, Value)
                End If
            End If
            Return Value
        End Function

        Public Function ReadPointerByte(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal ParamArray Offset As Integer()) As Byte
            Dim Value As Byte
            If Process.GetProcessesByName(EXENAME).Length <> 0 Then
                Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
                If Handle <> 0 Then
                    For Each I As Integer In Offset
                        ReadMemoryInteger(Handle, Pointer, Pointer)
                        Pointer += I
                    Next
                    ReadMemoryByte(Handle, Pointer, Value)
                End If
            Else
                MsgBox("can't find process")
            End If
            Return Value
        End Function

        Public Function ReadPointerInteger(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal ParamArray Offset As Integer()) As Integer
            Dim Value As Integer
            If Process.GetProcessesByName(EXENAME).Length <> 0 Then
                Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
                If Handle <> 0 Then
                    For Each I As Integer In Offset
                        ReadMemoryInteger(Handle, Pointer, Pointer)
                        Pointer += I
                    Next
                    ReadMemoryInteger(Handle, Pointer, Value)
                End If
            End If
            Return Value
        End Function

        Public Function ReadPointerFloat(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal ParamArray Offset As Integer()) As Single
            Dim Value As Single
            If Process.GetProcessesByName(EXENAME).Length <> 0 Then
                Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
                If Handle <> 0 Then
                    For Each I As Integer In Offset
                        ReadMemoryInteger(Handle, Pointer, Pointer)
                        Pointer += I
                    Next
                    ReadMemoryFloat(Handle, Pointer, Value)
                End If
            End If
            Return Value
        End Function

        Public Function ReadPointerDouble(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal ParamArray Offset As Integer()) As Double
            Dim Value As Double
            If Process.GetProcessesByName(EXENAME).Length <> 0 Then
                Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
                If Handle <> 0 Then
                    For Each I As Integer In Offset
                        ReadMemoryInteger(Handle, Pointer, Pointer)
                        Pointer += I
                    Next
                    ReadMemoryDouble(Handle, Pointer, Value)
                End If
            End If
            Return Value
        End Function

        Public Sub WriteByte(ByVal EXENAME As String, ByVal Address As Integer, ByVal Value As Byte)
            If Process.GetProcessesByName(EXENAME).Length <> 0 Then
                Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
                If Handle <> 0 Then
                    WriteMemoryByte(Handle, Address, Value)
                End If
            End If
        End Sub

        Public Sub WriteInteger(ByVal EXENAME As String, ByVal Address As Integer, ByVal Value As Integer)
            If Process.GetProcessesByName(EXENAME).Length <> 0 Then
                Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
                If Handle <> 0 Then
                    WriteMemoryInteger(Handle, Address, Value)
                End If
            End If
        End Sub

        Public Sub WriteFloat(ByVal EXENAME As String, ByVal Address As Integer, ByVal Value As Single)
            If Process.GetProcessesByName(EXENAME).Length <> 0 Then
                Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
                If Handle <> 0 Then
                    WriteMemoryFloat(Handle, Address, Value)
                End If
            End If
        End Sub

        Public Sub WriteDouble(ByVal EXENAME As String, ByVal Address As Integer, ByVal Value As Double)
            If Process.GetProcessesByName(EXENAME).Length <> 0 Then
                Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
                If Handle <> 0 Then
                    WriteMemoryDouble(Handle, Address, Value)
                End If
            End If
        End Sub

        Public Sub WritePointerByte(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal Value As Byte, ByVal ParamArray Offset As Integer())
            If Process.GetProcessesByName(EXENAME).Length <> 0 Then
                Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
                If Handle <> 0 Then
                    For Each I As Integer In Offset
                        ReadMemoryInteger(Handle, Pointer, Pointer)
                        Pointer += I
                    Next
                    WriteMemoryByte(Handle, Pointer, Value)
                End If
            End If
        End Sub

        Public Sub WritePointerInteger(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal Value As Integer, ByVal ParamArray Offset As Integer())
            If Process.GetProcessesByName(EXENAME).Length <> 0 Then
                Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
                If Handle <> 0 Then
                    For Each I As Integer In Offset
                        ReadMemoryInteger(Handle, Pointer, Pointer)
                        Pointer += I
                    Next
                    WriteMemoryInteger(Handle, Pointer, Value)
                End If
            End If
        End Sub

        Public Sub WritePointerFloat(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal Value As Single, ByVal ParamArray Offset As Integer())
            If Process.GetProcessesByName(EXENAME).Length <> 0 Then
                Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
                If Handle <> 0 Then
                    For Each I As Integer In Offset
                        ReadMemoryInteger(Handle, Pointer, Pointer)
                        Pointer += I
                    Next
                    WriteMemoryFloat(Handle, Pointer, Value)
                End If
            End If
        End Sub

        Public Sub WritePointerDouble(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal Value As Double, ByVal ParamArray Offset As Integer())
            If Process.GetProcessesByName(EXENAME).Length <> 0 Then
                Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
                If Handle <> 0 Then
                    For Each I As Integer In Offset
                        ReadMemoryInteger(Handle, Pointer, Pointer)
                        Pointer += I
                    Next
                    WriteMemoryDouble(Handle, Pointer, Value)
                End If
            End If
        End Sub
    End Module
'Kodlar Bitis







