Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try                     '例外処理のはじまり 
            If SerialPort1.IsOpen = True Then           'ポートはオープン済み
                MessageBox.Show("エラー", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            SerialPort1.PortName = cmbPortName.SelectedItem    'オープンするポート名を格納
            SerialPort1.Open()                          'ポートオープン        
        Catch ex As Exception           '例外処理            
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If SerialPort1.IsOpen = True Then   'ポートオープン済み
            SerialPort1.Close()                         'ポートクローズ
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text.Length = 0 Then                '送信データが無ければエラー
            MessageBox.Show("文字列入力エラー", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub                '処理を抜ける
        End If

        Try
            SerialPort1.WriteLine(TextBox1.Text)       '送信バッファにデータ書き込み
        Catch ex As Exception           '例外処理            
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim PortList As String()
        PortList = SerialPort.GetPortNames()

        cmbPortName.Items.Clear()

        'シリアルポート名をコンボボックスにセットする.
        Dim PortName As String
        For Each PortName In PortList
            cmbPortName.Items.Add(PortName)
        Next PortName

        If cmbPortName.Items.Count > 0 Then
            cmbPortName.SelectedIndex = 0
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim PortList As String()
        PortList = SerialPort.GetPortNames()

        cmbPortName.Items.Clear()

        'シリアルポート名をコンボボックスにセットする.
        Dim PortName As String
        For Each PortName In PortList
            cmbPortName.Items.Add(PortName)
        Next PortName

        If cmbPortName.Items.Count > 0 Then
            cmbPortName.SelectedIndex = 0
        End If
    End Sub
End Class
