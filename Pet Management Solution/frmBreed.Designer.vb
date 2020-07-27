<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBreed
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPetType = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBreed = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnActive = New System.Windows.Forms.Button()
        Me.btnDeactive = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(47, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pet Type:"
        '
        'txtPetType
        '
        Me.txtPetType.Location = New System.Drawing.Point(135, 72)
        Me.txtPetType.Multiline = True
        Me.txtPetType.Name = "txtPetType"
        Me.txtPetType.ReadOnly = True
        Me.txtPetType.Size = New System.Drawing.Size(118, 20)
        Me.txtPetType.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Pet Breed:"
        '
        'txtBreed
        '
        Me.txtBreed.Location = New System.Drawing.Point(135, 111)
        Me.txtBreed.Multiline = True
        Me.txtBreed.Name = "txtBreed"
        Me.txtBreed.Size = New System.Drawing.Size(118, 20)
        Me.txtBreed.TabIndex = 3
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.SkyBlue
        Me.btnAdd.Font = New System.Drawing.Font("Showcard Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(76, 200)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(78, 35)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Blue
        Me.btnExit.Font = New System.Drawing.Font("Showcard Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(160, 200)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(78, 35)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "E&XIT"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(47, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 19)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "ID:"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(135, 38)
        Me.txtID.Multiline = True
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(118, 20)
        Me.txtID.TabIndex = 7
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(287, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(380, 168)
        Me.DataGridView1.TabIndex = 8
        '
        'btnActive
        '
        Me.btnActive.BackColor = System.Drawing.Color.DarkOrchid
        Me.btnActive.Font = New System.Drawing.Font("Showcard Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActive.Location = New System.Drawing.Point(450, 209)
        Me.btnActive.Name = "btnActive"
        Me.btnActive.Size = New System.Drawing.Size(97, 35)
        Me.btnActive.TabIndex = 9
        Me.btnActive.Text = "Active"
        Me.btnActive.UseVisualStyleBackColor = False
        '
        'btnDeactive
        '
        Me.btnDeactive.BackColor = System.Drawing.Color.Violet
        Me.btnDeactive.Font = New System.Drawing.Font("Showcard Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeactive.Location = New System.Drawing.Point(553, 209)
        Me.btnDeactive.Name = "btnDeactive"
        Me.btnDeactive.Size = New System.Drawing.Size(114, 35)
        Me.btnDeactive.TabIndex = 10
        Me.btnDeactive.Text = "Deactive"
        Me.btnDeactive.UseVisualStyleBackColor = False
        '
        'frmBreed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.CadetBlue
        Me.ClientSize = New System.Drawing.Size(691, 259)
        Me.Controls.Add(Me.btnDeactive)
        Me.Controls.Add(Me.btnActive)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtBreed)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPetType)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmBreed"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Breed"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtPetType As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtBreed As TextBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnActive As Button
    Friend WithEvents btnDeactive As Button
End Class
