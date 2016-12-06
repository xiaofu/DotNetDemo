using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCustomControl
{
    /// <summary>
    /// Author: ��ҹսӥ����רע��DotNet��������ChengKing(ZhengJian)��
    /// ��ñ���ĸ����½�:��http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx��
    /// ����: ��������Ϊ����Asp.net������һЩ���¡���ת��ʱ�뱣��������Դ��
    /// </summary>
    [DefaultProperty("Text")]
    [DefaultEvent("ButtonSearchClick")]
    [ToolboxData("<{0}:SearchControl runat=server></{0}:SearchControl>")]
    public class SearchControl : CompositeControl
    {        
        private Button btnSearch;
        private TextBox tbSearchText;       
        
        [Category("����")]
        [DefaultValue("")]
        [Description("��ȡ�ı����ֵ")]
        public string Text
        {
            get
            {
                this.EnsureChildControls();
                return tbSearchText.Text;
            }
        }

        private static readonly object ButtonSearchClickObject = new object();
        public event SearchEventHandler ButtonSearchClick
        {
            add
            {
                base.Events.AddHandler(ButtonSearchClickObject, value);
            }
            remove
            {
                base.Events.RemoveHandler(ButtonSearchClickObject, value);
            }
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();
            btnSearch = new Button();
            btnSearch.ID = "btn";
            btnSearch.Text = "����";            
            btnSearch.Click += new EventHandler(btnSearch_Click);

            tbSearchText = new TextBox();
            tbSearchText.ID = "tb";           
            this.Controls.Add(btnSearch);
            this.Controls.Add(tbSearchText);
        }              

        protected virtual void OnButtonSearchClick(SearchEventArgs e)
        {
            SearchEventHandler ButtonSearchClickHandler = (SearchEventHandler)Events[ButtonSearchClickObject];
            if (ButtonSearchClickHandler != null)
            {
                ButtonSearchClickHandler(this, e);
            }
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            SearchEventArgs args = new SearchEventArgs();
            args.SearchValue = this.Text;
            OnButtonSearchClick( args );
        }  

        protected override void Render(HtmlTextWriter output)
        {
            output.AddAttribute(HtmlTextWriterAttribute.Border, "0px");
            output.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "5px");
            output.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "0px");
            output.RenderBeginTag(HtmlTextWriterTag.Table);
            output.RenderBeginTag(HtmlTextWriterTag.Tr);
            output.RenderBeginTag(HtmlTextWriterTag.Td);
            tbSearchText.RenderControl(output);
            output.RenderEndTag();
            output.RenderBeginTag(HtmlTextWriterTag.Td);
            btnSearch.RenderControl(output);
            output.RenderEndTag();
            output.RenderEndTag();
            output.RenderEndTag();
        }
    }
}