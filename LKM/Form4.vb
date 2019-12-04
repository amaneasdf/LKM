Public Class Form4

    Dim blnAdd As Boolean
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If btnAdd.Text.ToLower() = "add" Then
            txtFirstName.Enabled = True
            txtLastName.Enabled = True
            btnAdd.Text = "Save"
            btnEdit.Text = "Cancel"
            btnDelete.Enabled = False
            txtFirstName.Text = ""
            txtLastName.Text = ""
            blnAdd = True

        Else
            txtFirstName.Enabled = False
            txtLastName.Enabled = False
            btnAdd.Text = "Add"
            btnEdit.Text = "Edit"
            btnDelete.Enabled = True
            If blnAdd Then
                AddItemToListView()
            Else
                EditItemInListView()
            End If

        End If
    End Sub

    Private Sub AddItemToListView()
        Dim lv As ListViewItem = ListView1.Items.Add(txtFirstName.Text)
        lv.SubItems.Add(txtLastName.Text)
    End Sub
    Private Sub EditItemInListView()
        If ListView1.SelectedItems.Count > 0 Then
            ListView1.SelectedItems(0).Text = txtFirstName.Text
            ListView1.SelectedItems(0).SubItems(1).Text = txtLastName.Text
        End If
    End Sub



    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If txtFirstName.Text.Length > 0 Then
            If btnEdit.Text.ToLower() = "edit" Then
                txtFirstName.Enabled = True
                txtLastName.Enabled = True
                btnAdd.Text = "Save"
                btnEdit.Text = "Cancel"
                btnDelete.Enabled = False
                blnAdd = False
            Else
                txtFirstName.Enabled = False
                txtLastName.Enabled = False
                btnAdd.Text = "Add"
                btnEdit.Text = "Edit"
                btnDelete.Enabled = True
            End If
        Else
            MessageBox.Show("Please select record to edit")
        End If


    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If ListView1.SelectedItems.Count > 0 AndAlso MessageBox.Show("Do you want to delete this item?", "Confirm", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            ListView1.SelectedItems(0).Remove()
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            txtFirstName.Text = ListView1.SelectedItems(0).Text
            txtLastName.Text = ListView1.SelectedItems(0).SubItems(1).Text
        End If
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Columns.Add("frstname", 100, HorizontalAlignment.Left)
        ListView1.Columns.Add("lastname", 150, HorizontalAlignment.Left)
    End Sub
End Class