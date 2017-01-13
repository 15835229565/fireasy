using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Fireasy.Windows.Forms
{
    public abstract class Behavior : IDisposable
    {
        protected TextBoxBase m_textBox;
        protected int m_flags;
        protected bool m_noTextChanged;
        protected Selection m_selection;
        protected ErrorProvider m_errorProvider;
        private static string m_errorCaption;

        protected Behavior(TextBoxBase textBox, bool addEventHandlers)
        {
            if (textBox == null)
                throw new ArgumentNullException("没有指定TextBox");

            m_textBox = textBox;
            m_selection = new Selection(m_textBox);
            m_selection.TextChanging += new EventHandler(HandleTextChangingBySelection);

            if (addEventHandlers)
                AddEventHandlers();
        }

        protected Behavior(Behavior behavior)
        {
            if (behavior == null)
                throw new ArgumentNullException("没有指定Behavior");

            TextBox = behavior.TextBox;
            m_flags = behavior.m_flags;

            behavior.Dispose();
        }

        private void HandleTextChangingBySelection(object sender, EventArgs e)
        {
            m_noTextChanged = true;
        }

        protected virtual string GetValidText()
        {
            return m_textBox.Text;
        }

        public virtual bool UpdateText()
        {
            string validText = GetValidText();
            if (validText != m_textBox.Text)
            {
                m_textBox.Text = validText;
                return true;
            }
            return false;
        }

        public TextBoxBase TextBox
        {
            get { return m_textBox; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("没有指定Value");

                RemoveEventHandlers();

                m_textBox = value;
                m_selection = new Selection(m_textBox);
                m_selection.TextChanging += new EventHandler(HandleTextChangingBySelection);

                AddEventHandlers();
            }
        }

        /// <summary>
        /// 转换到整数。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected int ToInt(String text)
        {
            try
            {
                for (int i = 0, length = text.Length; i < length; i++)
                {
                    if (!Char.IsDigit(text[i]))
                        return Convert.ToInt32(text.Substring(0, i));
                }

                return Convert.ToInt32(text);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 转换到双精度。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected double ToDouble(String text)
        {
            double result = 0;
            double.TryParse(text, out result);
            return result;
        }

        public virtual int Flags
        {
            get { return m_flags; }
            set
            {
                if (m_flags == value)
                    return;

                m_flags = value;
                UpdateText();
            }
        }

        public void ModifyFlags(int flags, bool addOrRemove)
        {
            if (addOrRemove)
                Flags = m_flags | flags;
            else
                Flags = m_flags & ~flags;
        }

        public bool HasFlag(int flag)
        {
            return (m_flags & flag) != 0;
        }

        /// <summary>
        /// 显示错误提示信息。
        /// </summary>
        /// <param name="message"></param>
        public virtual void ShowErrorMessageBox(string message)
        {
            MessageBox.Show(m_textBox, message, ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// 显示错误提示信息。
        /// </summary>
        /// <param name="message"></param>
        public virtual void ShowErrorIcon(string message)
        {
            if (m_errorProvider == null)
            {
                if (message == "")
                    return;
                m_errorProvider = new ErrorProvider();
            }
            m_errorProvider.SetError(m_textBox, message);
        }

        /// <summary>
        /// 定义错误信息。
        /// </summary>
        public virtual string ErrorMessage
        {
            get
            {
                return "请输入有效的值";
            }
        }

        /// <summary>
        /// 错误信息的标题。
        /// </summary>
        public static string ErrorCaption
        {
            get
            {
                if (m_errorCaption == null)
                    return Application.ProductName;
                return m_errorCaption;
            }
            set { m_errorCaption = value; }
        }

        [Conditional("TRACE_AMS")]
        public void TraceLine(string message)
        {
            Trace.WriteLine(message);
        }

        public bool Validate()
        {
            return Validate(Flags, false);
        }

        public virtual bool Validate(int flags, bool setFocusIfNotValid)
        {
            ShowErrorIcon("");

            if ((flags & (int)ValidatingFlag.Max) == 0)
                return true;

            if ((flags & (int)ValidatingFlag.Max_IfEmpty) != 0 && m_textBox.Text.Length == 0)
            {
                if ((flags & (int)ValidatingFlag.Beep_IfEmpty) != 0)
                    NativeMethods.MessageBeep(MessageBoxIcon.Exclamation);

                if ((flags & (int)ValidatingFlag.SetValid_IfEmpty) != 0)
                {
                    UpdateText();
                    return true;
                }

                if ((flags & (int)ValidatingFlag.ShowIcon_IfEmpty) != 0)
                    ShowErrorIcon(ErrorMessage);

                if ((flags & (int)ValidatingFlag.ShowMessage_IfEmpty) != 0)
                    ShowErrorMessageBox(ErrorMessage);

                if (setFocusIfNotValid)
                    m_textBox.Focus();

                return false;
            }

            if ((flags & (int)ValidatingFlag.Max_IfInvalid) != 0 && m_textBox.Text.Length != 0 && !IsValid())
            {
                if ((flags & (int)ValidatingFlag.Beep_IfInvalid) != 0)
                    NativeMethods.MessageBeep(MessageBoxIcon.Exclamation);

                if ((flags & (int)ValidatingFlag.SetValid_IfInvalid) != 0)
                {
                    UpdateText();
                    return true;
                }

                if ((flags & (int)ValidatingFlag.ShowIcon_IfInvalid) != 0)
                    ShowErrorIcon(ErrorMessage);

                if ((flags & (int)ValidatingFlag.ShowMessage_IfInvalid) != 0)
                    ShowErrorMessageBox(ErrorMessage);

                if (setFocusIfNotValid)
                    m_textBox.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// 获取是否有效。
        /// </summary>
        /// <returns></returns>
        public virtual bool IsValid()
        {
            return true;
        }

        /// <summary>
        /// 添加事件委托。
        /// </summary>
        protected virtual void AddEventHandlers()
        {
            m_textBox.KeyDown += new KeyEventHandler(HandleKeyDown);
            m_textBox.KeyPress += new KeyPressEventHandler(HandleKeyPress);
            m_textBox.TextChanged += new EventHandler(HandleTextChanged);
            m_textBox.Validating += new CancelEventHandler(HandleValidating);
            m_textBox.LostFocus += new EventHandler(HandleLostFocus);
            m_textBox.DataBindings.CollectionChanged += new CollectionChangeEventHandler(HandleBindingChanges);
        }

        /// <summary>
        /// 移除事件委托。
        /// </summary>
        protected virtual void RemoveEventHandlers()
        {
            if (m_textBox == null)
                return;

            m_textBox.KeyDown -= new KeyEventHandler(HandleKeyDown);
            m_textBox.KeyPress -= new KeyPressEventHandler(HandleKeyPress);
            m_textBox.TextChanged -= new EventHandler(HandleTextChanged);
            m_textBox.Validating -= new CancelEventHandler(HandleValidating);
            m_textBox.LostFocus -= new EventHandler(HandleLostFocus);
            m_textBox.DataBindings.CollectionChanged -= new CollectionChangeEventHandler(HandleBindingChanges);
        }

        /// <summary>
        /// 销毁对象。
        /// </summary>
        public virtual void Dispose()
        {
            RemoveEventHandlers();
            m_textBox = null;
        }

        protected virtual void HandleKeyDown(object sender, KeyEventArgs e)
        {
            TraceLine("Behavior.HandleKeyDown " + e.KeyCode);

            e.Handled = false;
        }

        protected virtual void HandleKeyPress(object sender, KeyPressEventArgs e)
        {
            TraceLine("Behavior.HandleKeyPress " + e.KeyChar);

            e.Handled = false;
        }

        protected virtual void HandleTextChanged(object sender, EventArgs e)
        {
            TraceLine("Behavior.HandleTextChanged " + m_noTextChanged);

            if (!m_noTextChanged)
                UpdateText();

            m_noTextChanged = false;
        }

        protected virtual void HandleValidating(object sender, CancelEventArgs e)
        {
            TraceLine("Behavior.HandleValidating");

            e.Cancel = !Validate();
        }

        protected virtual void HandleLostFocus(object sender, EventArgs e)
        {
            TraceLine("Behavior.HandleLostFocus");
        }

        protected virtual void HandleBindingChanges(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Add)
            {
                Binding binding = (Binding)e.Element;
                binding.Format += new ConvertEventHandler(HandleBindingFormat);
                binding.Parse += new ConvertEventHandler(HandleBindingParse);
            }
        }

        protected virtual void HandleBindingFormat(object sender, ConvertEventArgs e)
        {
        }

        protected virtual void HandleBindingParse(object sender, ConvertEventArgs e)
        {
            if (e.Value.ToString() == "")
                e.Value = DBNull.Value;
        }
    }

    [Flags]
    public enum ValidatingFlag
    {
        /// <summary> 如果值无效则发出声响。 </summary>
        Beep_IfInvalid = 0x00000001,

        /// <summary> 如果值为空则发出声响。 </summary>
        Beep_IfEmpty = 0x00000002,

        /// <summary> 发出声响。 </summary>
        Beep = Beep_IfInvalid | Beep_IfEmpty,

        /// <summary> If the value is not valid, change its value to something valid. </summary>
        SetValid_IfInvalid = 0x00000004,

        /// <summary> If the value is empty, change its value to something valid. </summary>
        SetValid_IfEmpty = 0x00000008,

        /// <summary> If the value is empty or not valid, change its value to something valid. </summary>
        SetValid = SetValid_IfInvalid | SetValid_IfEmpty,

        /// <summary> If the value is not valid, show an error message box. </summary>
        ShowMessage_IfInvalid = 0x00000010,

        /// <summary> If the value is empty, show an error message box. </summary>
        ShowMessage_IfEmpty = 0x00000020,

        /// <summary> If the value is empty or not valid, show an error message box. </summary>
        ShowMessage = ShowMessage_IfInvalid | ShowMessage_IfEmpty,

        /// <summary> If the value is not valid, show a blinking icon next to it. </summary>
        ShowIcon_IfInvalid = 0x00000040,

        /// <summary> If the value is empty, show a blinking icon next to it. </summary>
        ShowIcon_IfEmpty = 0x00000080,

        /// <summary> If the value is empty or not valid, show a blinking icon next to it. </summary>
        ShowIcon = ShowIcon_IfInvalid | ShowIcon_IfEmpty,

        /// <summary> Combination of all IfInvalid flags (above); used internally by the program. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Max_IfInvalid = Beep_IfInvalid | SetValid_IfInvalid | ShowMessage_IfInvalid | ShowIcon_IfInvalid,

        /// <summary> Combination of all IfEmpty flags (above); used internally by the program. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Max_IfEmpty = Beep_IfEmpty | SetValid_IfEmpty | ShowMessage_IfEmpty | ShowIcon_IfEmpty,

        /// <summary> Combination of all flags; used internally by the program. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Max = Max_IfInvalid + Max_IfEmpty
    };

}
