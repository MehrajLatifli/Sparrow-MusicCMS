   M S B A M L   `   `   `  ????g  cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137akOclr-namespace:MahApps.Metro.IconPacks;assembly=MahApps.Metro.IconPacks.MaterialMahApps.Metro.IconPacks  5      C ?MusicCMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:MusicCMS.Views.Helper_Views.PlaylistMusic_Views/MusicCMS.Views.Helper_Views.PlaylistMusic_Views 5      I   CMusicCMS.Views.Helper_Views.PlaylistMusic_Views.PlaylistMusicWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      `IconOclr-namespace:MahApps.Metro.IconPacks;assembly=MahApps.Metro.IconPacks.Material     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      Ilocal=clr-namespace:MusicCMS.Views.Helper_Views.PlaylistMusic_Views  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	        ? Title$  Playlist??5
      $
??1250??5      $	??900??5       ? AllowsTransparency$
 True??5      
??????  ? 
ResizeMode$ NoResize=?5       ? WindowStartupLocation$ CenterScreen=?5       ? WindowStyle$
 None=?5      .??5      ? *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5   
   +  %Microsoft.Xaml.Behaviors.EventTrigger  5         	EventName$ Loaded??6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     PassEventArgsToCommand$
 True??6J   	   Command	 6(   ?? *LoadedCommand+6J   5        5      $ 	MouseDown??6   . 5        $
 True??6a   	 6(   ?? *&$PlaylistMusicWindow_MouseDownCommand+6a   5       
 ? ColumnDefinitions
 5$   
   ?? 5%      $??1* ?6    ? RowDefinitions 5(   
   ?? 5)      $??4* ?6   .+?5,   
   ?? $??0??5-      $??20q?5.       ?? CornerRadius$ 20??5/      ??51      ?? 53      .??55      ?  ? Offset$ 0Q?6#    ? Color$ #30ad9a??6.   ? 56      $ 1Q?6#   $ #18c274??6.   58       J? Effect 5<      3  -System.Windows.Media.Effects.DropShadowEffect  5>         
BlurRadius$ 20Q?5?         Opacity$	 0.4Q?5@         ShadowDepth$ 0Q?5A         Color$ #1fae7e??5B      ._?5F      ? .+?5I      ?? $	??350??5J      $	??250??5K      $??	0,150,0,0q?5L      $ 20??5M       J? Opacity$
 0.07Q?5N      ??5P      ?? 5R       j? 
AlignmentX$ Center=?5S       j? 
AlignmentY$ Center=?5T       ?? ImageSource$6 0../../../Asserts/Images/Logo/Mainlogo/LOGOag.png??5U      5Y      ? 5]      4  .System.Windows.Automation.AutomationProperties   AutomationId$ Grid1??6    5_      ?? 5`      $
??auto ?6(   ?? 5a      $
??auto ?6(   ?? 5b      $
??auto ?6(   .+?5e      ? $??0??6   
 5g      ?? 5i      $	??10* ?6/   ?? 5j      $??* ?6/   .+?5n      ?? $??1??5o      $??10q?5p       ? Cursor$
 Hand??5r         	appButton#??[  5s      ??5q      ?? *ExitAppCommand+.??5t      .   (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ WindowClose=?64     appButtonIcon#??[ 6G   5v      5x      ?? 5~      -   5         ??Name$ Searchborder??5      $??1??5?      $	??420??5?      $??50??5?      $??10,10,10,10q?5?      
?????? 
???????$??5q?5?      $ 20??5?      ._?5?      ?? -   5         ??Name$" SearchTextboxForMusicListbox??5?      $	??410??5?      $??10,0,0,0q?5?      $??Right=?5?      $??Center=?5?       ?? AcceptsReturn$
 True??5?       ?? 
AcceptsTab$
 True??5?      $
|?True??5?      $??25(?5?      $
??Bold"?5?       ?? IsUndoEnabled$ False??5?        ?? 	MaxLength$  15??5?      ! ?? MaxLines$! 15??5?        TextBoxStyle1#???  5?      " ?? TextWrapping$" WrapWithOverflow=?5?      "# ?? VerticalScrollBarVisibility$# Disabled=?5?      .??6D    5?        5?   "   $ TextChanged??61   . 5?   &     $
 True??6c   	 6<   ?? *MusicSearchCommand+6c   5?   #   .??5?   6   5?      5?      ?? 5?      $??2??5?      $	??650??5?      $??20,10,20,30q?5?      $ ScrollViewer??5?        AppleStyleScrollBarStyle#???  5?      $
??auto=?5?      $y?Visible=?5?      .??5?      ?? -   5        $ ??Name$$ MusicListbox??5?      
?????? $??0q?5?        _ListBoxItemStyle#??[ 5?      $??Disabled=?5?      $??Disabled=?5?      ??5?      ?? *Musics+??5?      ?? 5?   "   it??.R?5?   &   ? $??Center=?60   $??Center=?6M   5?   #   ??5?      ?? 5?   "   .R?5?   &   ? .+?5?   *   ?? $ border1??5?   -   $	??800??5?   -   $??75??5?   -   $??0,20,0,0q?5?   -     ListboxItemBackRoundColor#??[ 5?   -     ListboxItemBorderColor#??[ 5?   -   $??5q?5?   -   $ 20??5?   -   ._?5?   .   ? 
 5?   2   ?? 5?   6   $
??0.5* ?6G   ?? 5?   6   $??4* ?6G   ?? 5?   6   $
??0.5* ?6G   .+?5?   2   A? $??0??5?   5   $??50??5?   5   $??50??5?   5   $??5,0,0,0q?5?   5   ??5?   6   ?? 5?   :   imagelb?? 6V   ?? % ?? Path$% 
ImageMusic?& ?? Mode$& TwoWay=?' ?? UpdateSourceTrigger$' PropertyChanged=?5?   3   ?? 5?   2   ( ??Name$( MusicNamelabel??5?   5   $??1??5?   5   $	??700??5?   5   $
??auto??5?   5   $??6,0,0,16q?5?   5   $
??Left=?5?   5   $??Bottom=?5?   5   $??20(?5?   5   $
??Bold"?5?   5     ListboxItemForeGroundColor#??[ 5?   5   ??5?   5   ?? $% 	MusicName?$& TwoWay=?$' PropertyChanged=?5?   5   ?? 5?   2   ) ??Name$) AddMusictoPlaylisCommand??5?   5   $??2??5   5   $
??auto??5  5   $??5q?5  5   $
 Hand??5  5   $
{?True??5  5     RegistrationButton#??[ 5  5    5  6     5	  :   $! PreviewMouseRightButtonDown??6I   . 5
  >     	 6T   ?? * ?? RelativeSource* ?? + ?? Mode$+ FindAncestor=?, ?? AncestorLevel$, 1??- ?? AncestorTypeI  CMusicCMS.Views.Helper_Views.PlaylistMusic_Views.PlaylistMusicWindow"-  $*% $DataContext.AddMusictoPlaylisCommand?.   CommandParameter. 6  ?? / ?? ElementName$/ MusicListbox??$% SelectedItem?5  ;   .??5  6   ? .+?5  :     0  Name$0 AddmusicPlaylistKind??5  =   $ PlusBox=?5  =    	 RegistrationButtonIcon#??[	 5  =   5  7   5  3   5  /   5  +   5!  '   5#  #   5&     5)     5+     5,     5.     54     57     