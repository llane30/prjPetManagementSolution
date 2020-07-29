<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPetType
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
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.dgType = New System.Windows.Forms.DataGridView()
        Me.btnActive = New System.Windows.Forms.Button()
        Me.btnDeactive = New System.Windows.Forms.Button()
        Me.txtType = New System.Windows.Forms.TextBox()
        Me.btnPlus = New System.Windows.Forms.Button()
        CType(Me.dgType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Pet Type:"
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.SkyBlue
        Me.btnAdd.Font = New System.Drawing.Font("Showcard Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(65, 133)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(87, 33)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Blue
        Me.btnExit.Font = New System.Drawing.Font("Showcard Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(158, 133)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(87, 33)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "E&XIT"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poor Richard", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "ID:"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(95, 38)
        Me.txtID.Multiline = True
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(150, 27)
        Me.txtID.TabIndex = 5
        '
        'dgType
        '
        Me.dgType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgType.Location = New System.Drawing.Point(300, 12)
        Me.dgType.Name = "dgType"
        Me.dgType.Size = New System.Drawing.Size(449, 229)
        Me.dgType.TabIndex = 6
        '
        'btnActive
        '
        Me.btnActive.BackColor = System.Drawing.Color.MediumOrchid
        Me.btnActive.Font = New System.Drawing.Font("Showcard Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActive.Location = New System.Drawing.Point(517, 259)
        Me.btnActive.Name = "btnActive"
        Me.btnActive.Size = New System.Drawing.Size(87, 33)
        Me.btnActive.TabIndex = 7
        Me.btnActive.Text = "Active"
        Me.btnActive.UseVisualStyleBackColor = False
        '
        'btnDeactive
        '
        Me.btnDeactive.BackColor = System.Drawing.Color.DarkOrchid
        Me.btnDeactive.Font = New System.Drawing.Font("Showcard Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeactive.Location = New System.Drawing.Point(610, 259)
        Me.btnDeactive.Name = "btnDeactive"
        Me.btnDeactive.Size = New System.Drawing.Size(143, 33)
        Me.btnDeactive.TabIndex = 8
        Me.btnDeactive.Text = "Deactivate"
        Me.btnDeactive.UseVisualStyleBackColor = False
        '
        'txtType
        '
        Me.txtType.Location = New System.Drawing.Point(95, 83)
        Me.txtType.Name = "txtType"
        Me.txtType.Size = New System.Drawing.Size(150, 20)
        Me.txtType.TabIndex = 9
        '
        'btnPlus
        '
        Me.btnPlus.Location = New System.Drawing.Point(251, 38)
        Me.btnPlus.Name = "btnPlus"
        Me.btnPlus.Size = New System.Drawing.Size(37, 27)
        Me.btnPlus.TabIndex = 10
        Me.btnPlus.Text = "+"
        Me.btnPlus.UseVisualStyleBackColor = True
        '
        'frmPetType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tan
        Me.ClientSize = New System.Drawing.Size(765, 301)
        Me.Controls.Add(Me.btnPlus)
        Me.Controls.Add(Me.txtType)
        Me.Controls.Add(Me.btnDeactive)
        Me.Controls.Add(Me.btnActive)
        Me.Controls.Add(Me.dgType)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmPetType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PetType"
        CType(Me.dgType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents dgType As DataGridView
    Friend WithEvents btnActive As Button
    Friend WithEvents btnDeactive As Button
    Friend WithEvents txtType As TextBox
    Friend WithEvents btnPlus As Button
End Class
