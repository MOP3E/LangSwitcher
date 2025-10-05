// CodeContracts
// 
// Copyright (c) Microsoft Corporation
// 
// All rights reserved. 
// 
// MIT License
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#region Assembly System.Windows.Forms.dll, v4.0.30319
// C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.Windows.Forms.dll
#endregion

namespace LangSwitcherLib
{
    // Summary:
    //     Specifies key codes and modifiers.
    public enum Keys
    {
        /// <Summary>
        /// The bitmask to extract modifiers from a key value.
        /// </Summary>
        Modifiers = -65536,
        /// <Summary>
        /// No key pressed.
        /// </Summary>
        None = 0,
        /// <Summary>
        /// The left mouse button.
        /// </Summary>
        LButton = 1,
        /// <Summary>
        /// The right mouse button.
        /// </Summary>
        RButton = 2,
        /// <Summary>
        /// The CANCEL key.
        /// </Summary>
        Cancel = 3,
        /// <Summary>
        /// The middle mouse button (three-button mouse).
        /// </Summary>
        MButton = 4,
        /// <Summary>
        /// The first x mouse button (five-button mouse).
        /// </Summary>
        XButton1 = 5,
        /// <Summary>
        /// The second x mouse button (five-button mouse).
        /// </Summary>
        XButton2 = 6,
        /// <Summary>
        /// The BACKSPACE key.
        /// </Summary>
        Back = 8,
        /// <Summary>
        /// The TAB key.
        /// </Summary>
        Tab = 9,
        /// <Summary>
        /// The LINEFEED key.
        /// </Summary>
        LineFeed = 10,
        /// <Summary>
        /// The CLEAR key.
        /// </Summary>
        Clear = 12,
        /// <Summary>
        /// The ENTER key.
        /// </Summary>
        Enter = 13,
        /// <Summary>
        /// The RETURN key.
        /// </Summary>
        Return = 13,
        /// <Summary>
        /// The SHIFT key.
        /// </Summary>
        ShiftKey = 16,
        /// <Summary>
        /// The CTRL key.
        /// </Summary>
        ControlKey = 17,
        /// <Summary>
        /// The ALT key.
        /// </Summary>
        Menu = 18,
        /// <Summary>
        /// The PAUSE key.
        /// </Summary>
        Pause = 19,
        /// <Summary>
        /// The CAPS LOCK key.
        /// </Summary>
        CapsLock = 20,
        /// <Summary>
        /// The CAPS LOCK key.
        /// </Summary>
        Capital = 20,
        /// <Summary>
        /// The IME Kana mode key.
        /// </Summary>
        KanaMode = 21,
        /// <Summary>
        /// The IME Hanguel mode key. (maintained for compatibility; use HangulMode)
        HanguelMode = 21,
        /// <Summary>
        /// The IME Hangul mode key.
        /// </Summary>
        HangulMode = 21,
        /// <Summary>
        /// The IME Junja mode key.
        /// </Summary>
        JunjaMode = 23,
        /// <Summary>
        /// The IME final mode key.
        /// </Summary>
        FinalMode = 24,
        /// <Summary>
        /// The IME Kanji mode key.
        /// </Summary>
        KanjiMode = 25,
        /// <Summary>
        /// The IME Hanja mode key.
        /// </Summary>
        HanjaMode = 25,
        /// <Summary>
        /// The ESC key.
        /// </Summary>
        Escape = 27,
        /// <Summary>
        /// The IME convert key.
        /// </Summary>
        IMEConvert = 28,
        /// <Summary>
        /// The IME nonconvert key.
        /// </Summary>
        IMENonconvert = 29,
        /// <Summary>
        /// The IME accept key. Obsolete, use System.Windows.Forms.Keys.IMEAccept instead.
        /// </Summary>
        IMEAceept = 30,
        /// <Summary>
        /// The IME accept key, replaces System.Windows.Forms.Keys.IMEAceept.
        /// </Summary>
        IMEAccept = 30,
        /// <Summary>
        /// The IME mode change key.
        /// </Summary>
        IMEModeChange = 31,
        /// <Summary>
        /// The SPACEBAR key.
        /// </Summary>
        Space = 32,
        /// <Summary>
        /// The PAGE UP key.
        /// </Summary>
        Prior = 33,
        /// <Summary>
        /// The PAGE UP key.
        /// </Summary>
        PageUp = 33,
        /// <Summary>
        /// The PAGE DOWN key.
        /// </Summary>
        Next = 34,
        /// <Summary>
        /// The PAGE DOWN key.
        /// </Summary>
        PageDown = 34,
        /// <Summary>
        /// The END key.
        /// </Summary>
        End = 35,
        /// <Summary>
        /// The HOME key.
        /// </Summary>
        Home = 36,
        /// <Summary>
        /// The LEFT ARROW key.
        /// </Summary>
        Left = 37,
        /// <Summary>
        /// The UP ARROW key.
        /// </Summary>
        Up = 38,
        /// <Summary>
        /// The RIGHT ARROW key.
        /// </Summary>
        Right = 39,
        /// <Summary>
        /// The DOWN ARROW key.
        /// </Summary>
        Down = 40,
        /// <Summary>
        /// The SELECT key.
        /// </Summary>
        Select = 41,
        /// <Summary>
        /// The PRINT key.
        /// </Summary>
        Print = 42,
        /// <Summary>
        /// The EXECUTE key.
        /// </Summary>
        Execute = 43,
        /// <Summary>
        /// The PRINT SCREEN key.
        /// </Summary>
        PrintScreen = 44,
        /// <Summary>
        /// The PRINT SCREEN key.
        /// </Summary>
        Snapshot = 44,
        /// <Summary>
        /// The INS key.
        /// </Summary>
        Insert = 45,
        /// <Summary>
        /// The DEL key.
        /// </Summary>
        Delete = 46,
        /// <Summary>
        /// The HELP key.
        /// </Summary>
        Help = 47,
        /// <Summary>
        /// The 0 key.
        /// </Summary>
        D0 = 48,
        /// <Summary>
        /// The 1 key.
        /// </Summary>
        D1 = 49,
        /// <Summary>
        /// The 2 key.
        /// </Summary>
        D2 = 50,
        /// <Summary>
        /// The 3 key.
        /// </Summary>
        D3 = 51,
        /// <Summary>
        /// The 4 key.
        /// </Summary>
        D4 = 52,
        /// <Summary>
        /// The 5 key.
        /// </Summary>
        D5 = 53,
        /// <Summary>
        /// The 6 key.
        /// </Summary>
        D6 = 54,
        /// <Summary>
        /// The 7 key.
        /// </Summary>
        D7 = 55,
        /// <Summary>
        /// The 8 key.
        /// </Summary>
        D8 = 56,
        /// <Summary>
        /// The 9 key.
        /// </Summary>
        D9 = 57,
        /// <Summary>
        /// The A key.
        /// </Summary>
        A = 65,
        /// <Summary>
        /// The B key.
        /// </Summary>
        B = 66,
        /// <Summary>
        /// The C key.
        /// </Summary>
        C = 67,
        /// <Summary>
        /// The D key.
        /// </Summary>
        D = 68,
        /// <Summary>
        /// The E key.
        /// </Summary>
        E = 69,
        /// <Summary>
        /// The F key.
        /// </Summary>
        F = 70,
        /// <Summary>
        /// The G key.
        /// </Summary>
        G = 71,
        /// <Summary>
        /// The H key.
        /// </Summary>
        H = 72,
        /// <Summary>
        /// The I key.
        /// </Summary>
        I = 73,
        /// <Summary>
        /// The J key.
        /// </Summary>
        J = 74,
        /// <Summary>
        /// The K key.
        /// </Summary>
        K = 75,
        /// <Summary>
        /// The L key.
        /// </Summary>
        L = 76,
        /// <Summary>
        /// The M key.
        /// </Summary>
        M = 77,
        /// <Summary>
        /// The N key.
        /// </Summary>
        N = 78,
        /// <Summary>
        /// The O key.
        /// </Summary>
        O = 79,
        /// <Summary>
        /// The P key.
        /// </Summary>
        P = 80,
        /// <Summary>
        /// The Q key.
        /// </Summary>
        Q = 81,
        /// <Summary>
        /// The R key.
        /// </Summary>
        R = 82,
        /// <Summary>
        /// The S key.
        /// </Summary>
        S = 83,
        /// <Summary>
        /// The T key.
        /// </Summary>
        T = 84,
        /// <Summary>
        /// The U key.
        /// </Summary>
        U = 85,
        /// <Summary>
        /// The V key.
        /// </Summary>
        V = 86,
        /// <Summary>
        /// The W key.
        /// </Summary>
        W = 87,
        /// <Summary>
        /// The X key.
        /// </Summary>
        X = 88,
        /// <Summary>
        /// The Y key.
        /// </Summary>
        Y = 89,
        /// <Summary>
        /// The Z key.
        /// </Summary>
        Z = 90,
        /// <Summary>
        /// The left Windows logo key (Microsoft Natural Keyboard).
        /// </Summary>
        LWin = 91,
        /// <Summary>
        /// The right Windows logo key (Microsoft Natural Keyboard).
        /// </Summary>
        RWin = 92,
        /// <Summary>
        /// The application key (Microsoft Natural Keyboard).
        /// </Summary>
        Apps = 93,
        /// <Summary>
        /// The computer sleep key.
        /// </Summary>
        Sleep = 95,
        /// <Summary>
        /// The 0 key on the numeric keypad.
        /// </Summary>
        NumPad0 = 96,
        /// <Summary>
        /// The 1 key on the numeric keypad.
        /// </Summary>
        NumPad1 = 97,
        /// <Summary>
        /// The 2 key on the numeric keypad.
        /// </Summary>
        NumPad2 = 98,
        /// <Summary>
        /// The 3 key on the numeric keypad.
        /// </Summary>
        NumPad3 = 99,
        /// <Summary>
        /// The 4 key on the numeric keypad.
        /// </Summary>
        NumPad4 = 100,
        /// <Summary>
        /// The 5 key on the numeric keypad.
        /// </Summary>
        NumPad5 = 101,
        /// <Summary>
        /// The 6 key on the numeric keypad.
        /// </Summary>
        NumPad6 = 102,
        /// <Summary>
        /// The 7 key on the numeric keypad.
        /// </Summary>
        NumPad7 = 103,
        /// <Summary>
        /// The 8 key on the numeric keypad.
        /// </Summary>
        NumPad8 = 104,
        /// <Summary>
        /// The 9 key on the numeric keypad.
        /// </Summary>
        NumPad9 = 105,
        /// <Summary>
        /// The multiply key.
        /// </Summary>
        Multiply = 106,
        /// <Summary>
        /// The add key.
        /// </Summary>
        Add = 107,
        /// <Summary>
        /// The separator key.
        /// </Summary>
        Separator = 108,
        /// <Summary>
        /// The subtract key.
        /// </Summary>
        Subtract = 109,
        /// <Summary>
        /// The decimal key.
        /// </Summary>
        Decimal = 110,
        /// <Summary>
        /// The divide key.
        /// </Summary>
        Divide = 111,
        /// <Summary>
        /// The F1 key.
        /// </Summary>
        F1 = 112,
        /// <Summary>
        /// The F2 key.
        /// </Summary>
        F2 = 113,
        /// <Summary>
        /// The F3 key.
        /// </Summary>
        F3 = 114,
        /// <Summary>
        /// The F4 key.
        /// </Summary>
        F4 = 115,
        /// <Summary>
        /// The F5 key.
        /// </Summary>
        F5 = 116,
        /// <Summary>
        /// The F6 key.
        /// </Summary>
        F6 = 117,
        /// <Summary>
        /// The F7 key.
        /// </Summary>
        F7 = 118,
        /// <Summary>
        /// The F8 key.
        /// </Summary>
        F8 = 119,
        /// <Summary>
        /// The F9 key.
        /// </Summary>
        F9 = 120,
        /// <Summary>
        /// The F10 key.
        /// </Summary>
        F10 = 121,
        /// <Summary>
        /// The F11 key.
        /// </Summary>
        F11 = 122,
        /// <Summary>
        /// The F12 key.
        /// </Summary>
        F12 = 123,
        /// <Summary>
        /// The F13 key.
        /// </Summary>
        F13 = 124,
        /// <Summary>
        /// The F14 key.
        /// </Summary>
        F14 = 125,
        /// <Summary>
        /// The F15 key.
        /// </Summary>
        F15 = 126,
        /// <Summary>
        /// The F16 key.
        /// </Summary>
        F16 = 127,
        /// <Summary>
        /// The F17 key.
        /// </Summary>
        F17 = 128,
        /// <Summary>
        /// The F18 key.
        /// </Summary>
        F18 = 129,
        /// <Summary>
        /// The F19 key.
        /// </Summary>
        F19 = 130,
        /// <Summary>
        /// The F20 key.
        /// </Summary>
        F20 = 131,
        /// <Summary>
        /// The F21 key.
        /// </Summary>
        F21 = 132,
        /// <Summary>
        /// The F22 key.
        /// </Summary>
        F22 = 133,
        /// <Summary>
        /// The F23 key.
        /// </Summary>
        F23 = 134,
        /// <Summary>
        /// The F24 key.
        /// </Summary>
        F24 = 135,
        /// <Summary>
        /// The NUM LOCK key.
        /// </Summary>
        NumLock = 144,
        /// <Summary>
        /// The SCROLL LOCK key.
        /// </Summary>
        Scroll = 145,
        /// <Summary>
        /// The left SHIFT key.
        /// </Summary>
        LShiftKey = 160,
        /// <Summary>
        /// The right SHIFT key.
        /// </Summary>
        RShiftKey = 161,
        /// <Summary>
        /// The left CTRL key.
        /// </Summary>
        LControlKey = 162,
        /// <Summary>
        /// The right CTRL key.
        /// </Summary>
        RControlKey = 163,
        /// <Summary>
        /// The left ALT key.
        /// </Summary>
        LMenu = 164,
        /// <Summary>
        /// The right ALT key.
        /// </Summary>
        RMenu = 165,
        /// <Summary>
        /// The browser back key (Windows 2000 or later).
        /// </Summary>
        BrowserBack = 166,
        /// <Summary>
        /// The browser forward key (Windows 2000 or later).
        /// </Summary>
        BrowserForward = 167,
        /// <Summary>
        /// The browser refresh key (Windows 2000 or later).
        /// </Summary>
        BrowserRefresh = 168,
        /// <Summary>
        /// The browser stop key (Windows 2000 or later).
        /// </Summary>
        BrowserStop = 169,
        /// <Summary>
        /// The browser search key (Windows 2000 or later).
        /// </Summary>
        BrowserSearch = 170,
        /// <Summary>
        /// The browser favorites key (Windows 2000 or later).
        /// </Summary>
        BrowserFavorites = 171,
        /// <Summary>
        /// The browser home key (Windows 2000 or later).
        /// </Summary>
        BrowserHome = 172,
        /// <Summary>
        /// The volume mute key (Windows 2000 or later).
        /// </Summary>
        VolumeMute = 173,
        /// <Summary>
        /// The volume down key (Windows 2000 or later).
        /// </Summary>
        VolumeDown = 174,
        /// <Summary>
        /// The volume up key (Windows 2000 or later).
        /// </Summary>
        VolumeUp = 175,
        /// <Summary>
        /// The media next track key (Windows 2000 or later).
        /// </Summary>
        MediaNextTrack = 176,
        /// <Summary>
        /// The media previous track key (Windows 2000 or later).
        /// </Summary>
        MediaPreviousTrack = 177,
        /// <Summary>
        /// The media Stop key (Windows 2000 or later).
        /// </Summary>
        MediaStop = 178,
        /// <Summary>
        /// The media play pause key (Windows 2000 or later).
        /// </Summary>
        MediaPlayPause = 179,
        /// <Summary>
        /// The launch mail key (Windows 2000 or later).
        /// </Summary>
        LaunchMail = 180,
        /// <Summary>
        /// The select media key (Windows 2000 or later).
        /// </Summary>
        SelectMedia = 181,
        /// <Summary>
        /// The start application one key (Windows 2000 or later).
        /// </Summary>
        LaunchApplication1 = 182,
        /// <Summary>
        /// The start application two key (Windows 2000 or later).
        /// </Summary>
        LaunchApplication2 = 183,
        /// <Summary>
        /// The OEM 1 key.
        /// </Summary>
        Oem1 = 186,
        /// <Summary>
        /// The OEM Semicolon key on a US standard keyboard (Windows 2000 or later).
        /// </Summary>
        OemSemicolon = 186,
        /// <Summary>
        /// The OEM plus key on any country/region keyboard (Windows 2000 or later).
        /// </Summary>
        Oemplus = 187,
        /// <Summary>
        /// The OEM comma key on any country/region keyboard (Windows 2000 or later).
        /// </Summary>
        Oemcomma = 188,
        /// <Summary>
        /// The OEM minus key on any country/region keyboard (Windows 2000 or later).
        /// </Summary>
        OemMinus = 189,
        /// <Summary>
        /// The OEM period key on any country/region keyboard (Windows 2000 or later).
        /// </Summary>
        OemPeriod = 190,
        /// <Summary>
        /// The OEM question mark key on a US standard keyboard (Windows 2000 or later).
        /// </Summary>
        OemQuestion = 191,
        /// <Summary>
        /// The OEM 2 key.
        /// </Summary>
        Oem2 = 191,
        /// <Summary>
        /// The OEM tilde key on a US standard keyboard (Windows 2000 or later).
        /// </Summary>
        Oemtilde = 192,
        /// <Summary>
        /// The OEM 3 key.
        /// </Summary>
        Oem3 = 192,
        /// <Summary>
        /// The OEM 4 key.
        /// </Summary>
        Oem4 = 219,
        /// <Summary>
        /// The OEM open bracket key on a US standard keyboard (Windows 2000 or later).
        /// </Summary>
        OemOpenBrackets = 219,
        /// <Summary>
        /// The OEM pipe key on a US standard keyboard (Windows 2000 or later).
        /// </Summary>
        OemPipe = 220,
        /// <Summary>
        /// The OEM 5 key.
        /// </Summary>
        Oem5 = 220,
        /// <Summary>
        /// The OEM 6 key.
        /// </Summary>
        Oem6 = 221,
        /// <Summary>
        /// The OEM close bracket key on a US standard keyboard (Windows 2000 or later).
        /// </Summary>
        OemCloseBrackets = 221,
        /// <Summary>
        /// The OEM 7 key.
        /// </Summary>
        Oem7 = 222,
        /// <Summary>
        /// The OEM singled/double quote key on a US standard keyboard (Windows 2000
        /// or later).
        /// </Summary>
        OemQuotes = 222,
        /// <Summary>
        /// The OEM 8 key.
        /// </Summary>
        Oem8 = 223,
        /// <Summary>
        /// The OEM 102 key.
        /// </Summary>
        Oem102 = 226,
        /// <Summary>
        /// The OEM angle bracket or backslash key on the RT 102 key keyboard (Windows
        /// 2000 or later).
        /// </Summary>
        OemBackslash = 226,
        /// <Summary>
        /// The PROCESS KEY key.
        /// </Summary>
        ProcessKey = 229,
        /// <Summary>
        /// Used to pass Unicode characters as if they were keystrokes. The Packet key
        /// value is the low word of a 32-bit virtual-key value used for non-keyboard
        /// input methods.
        /// </Summary>
        Packet = 231,
        /// <Summary>
        /// The ATTN key.
        /// </Summary>
        Attn = 246,
        /// <Summary>
        /// The CRSEL key.
        /// </Summary>
        Crsel = 247,
        /// <Summary>
        /// The EXSEL key.
        /// </Summary>
        Exsel = 248,
        /// <Summary>
        /// The ERASE EOF key.
        /// </Summary>
        EraseEof = 249,
        /// <Summary>
        /// The PLAY key.
        /// </Summary>
        Play = 250,
        /// <Summary>
        /// The ZOOM key.
        /// </Summary>
        Zoom = 251,
        /// <Summary>
        /// A constant reserved for future use.
        /// </Summary>
        NoName = 252,
        /// <Summary>
        /// The PA1 key.
        /// </Summary>
        Pa1 = 253,
        /// <Summary>
        /// The CLEAR key.
        /// </Summary>
        OemClear = 254,
        /// <Summary>
        /// The bitmask to extract a key code from a key value.
        /// </Summary>
        KeyCode = 65535,
        /// <Summary>
        /// The SHIFT modifier key.
        /// </Summary>
        Shift = 65536,
        /// <Summary>
        /// The CTRL modifier key.
        /// </Summary>
        Control = 131072,
        /// <Summary>
        /// The ALT modifier key.
        /// </Summary>
        Alt = 262144,
    }
}