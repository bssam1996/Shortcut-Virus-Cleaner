Public Class About

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://www.facebook.com/bassam.hesham.abozied")
        LinkLabel1.Links(LinkLabel1.Links.IndexOf(e.Link)).Visited = True
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        System.Diagnostics.Process.Start("http://www.bassamsc.netne.net")
        LinkLabel2.Links(LinkLabel2.Links.IndexOf(e.Link)).Visited = True
    End Sub

    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label3.Text = "Version : " & System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()
    End Sub
End Class