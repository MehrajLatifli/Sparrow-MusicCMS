   M S B A M L   `   `   `  ????I  EMusicCMS Admin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MusicCMS_Admin.HelpersMusicCMS_Admin.Helpers  5      g cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137akOclr-namespace:MahApps.Metro.IconPacks;assembly=MahApps.Metro.IconPacks.MaterialMahApps.Metro.IconPacks 5      U/clr-namespace:MusicCMS_Admin.Views.UserControls!MusicCMS_Admin.Views.UserControls  5	      0    *MusicCMS_Admin.Views.UserControls.Music_UC   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      9Behavior$clr-namespace:MusicCMS_Admin.Helpers     5      `IconOclr-namespace:MahApps.Metro.IconPacks;assembly=MahApps.Metro.IconPacks.Material     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      ;local/clr-namespace:MusicCMS_Admin.Views.UserControls  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      $??600px??5      .??5      ? *  $Microsoft.Xaml.Behaviors.Interaction    Triggers  5   
   +  %Microsoft.Xaml.Behaviors.EventTrigger  5         	EventName$ Loaded??6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     PassEventArgsToCommand$
 True??6J      Command 6(   ?? *LoadedCommand+6J   5       ? ColumnDefinitions 5   
   ?? 5      $??1* ?6   ?? 5      $??* ?6   .+?5   
   ?? $??0??5      $??20q?5        ?? CornerRadius$ 20??5!      ??5#      ?? 5%      .??5'      ?  ? Offset$ 0Q?6#    ? Color$ #30ad9a??6.   ? 5(      $ 1Q?6#   $ #18c274??6.   5*      	 J? Effect	 5.      3  -System.Windows.Media.Effects.DropShadowEffect  50      
   
BlurRadius$
 20Q?51         Opacity$	 0.4Q?52         ShadowDepth$ 0Q?53         Color$ #1fae7e??54      ._?58      ? .+?5;      ?? $	??350??5<      $	??250??5=      $ 20??5>       J? Opacity$
 0.07Q?5?      ??5A      ?? 5C       j? 
AlignmentX$ Center=?5D       j? 
AlignmentY$ Center=?5E       ?? ImageSource$3 -../../Asserts/Images/Logo/Mainlogo/LOGOag.png??5F      5J      ? 5N      $	??600??6   4  .System.Windows.Automation.AutomationProperties   AutomationId$ Grid1??6'    ? RowDefinitions 5P      ?? 5Q      $
??auto ?6(   ?? 5R      $
??auto ?6(   ?? 5S      $??400px ?6(   .+?5V      ?? $??0??5W      $??Center=?5X      $??Center=?5Y      $ Label1??5Z      $??Music??5[      $??20(?5\      $
??Bold"?5]      
???????5^      ?? 5`      -   5         ??Name$ Searchborder??5a      $??1??5b      $	??320??5c      $??50??5d      $??10,10,10,10q?5e      
?????? 
???????$??5q?5h      $ 20??5i      ._?5k      ?? -   5         ??Name$" SearchTextboxForMusicListbox??5l      $??10,0,0,0q?5m      $??Center=?5n      4   .MusicCMS_Admin.Helpers.DisableCapsLockBehavior   IsCapsLockDisabled$
 True??5o       ?? AcceptsReturn$
 True??5p       ?? 
AcceptsTab$
 True??5q       ?? CharacterCasing$ Lower=?5r      $
|?True??5s      $??25(?5t      $
??Bold"?5u       ?? IsUndoEnabled$ False??5v       ?? 	MaxLength$ 15??5w       ?? MaxLines$ 15??5x         TextBoxStyle1#???   5y       ?? TextWrapping$ WrapWithOverflow=?5z      " ?? VerticalScrollBarVisibility$ Disabled=?5{      .??6D     5}        5   "   $ TextChanged??61   . 5?   &     $
 True??6c    6<   ?? *MusicSearchCommand+6c   5?   #   .??5?   6   5?      5?      ?? 5?      $??2??5?      $??20,10,20,-2q?5?      $ ScrollViewer1??5?        AppleStyleScrollBarStyle#???  5?      .??5?      ?? -   5         ??Name$ MusicListbox??5?      
?????? $??0q?5?        _ListBoxItemStyle#??[ 5?      $??Disabled=?5?      $??Disabled=?5?      ??5?      ?? *Musics+  ?? SelectedItem  5?      ?? *Music+  5?        5?   "   $  PreviewMouseLeftButtonDown??61   . 5?   &      6<   ?? *MusicListboxMouseDoubleClick+!   CommandParameter! 6m   ?? " ?? ElementName$" MusicListbox??# ?? Path$# SelectedItem?5?   #   ??5?      ?? 5?   "   it2??.R?5?   &   ? $??Center=?60   $??Center=?6M   5?   #   ??5?      ?? 5?   "   .R?5?   &   ? .+?5?   *   ?? $ border1??5?   -   $	??375??5?   -   $??50??5?   -   $??0,10,0,0q?5?   -     ListboxItemBackRoundColor#??[ 5?   -     ListboxItemBorderColor#??[ 5?   -   $??5q?5?   -   $ 20??5?   -   ._?5?   .   ?  5?   2   ?? 5?   6   $
??0.5* ?6G   ?? 5?   6   $??4* ?6G   ?? 5?   6   $
??1.5* ?6G   .+?5?   2   A? $??0??5?   5   $??25??5?   5   $??25??5?   5   $??5,0,0,0q?5?   5   ??5?   6   ?? 5?   :   imagelb?? 6V   ?? $# 
ImageMusic?$ ?? Mode$$ TwoWay=?% ?? UpdateSourceTrigger$% PropertyChanged=?5?   3   ?? 5?   2   & ??Name$& ArtistNamelabel??5?   5   $??1??5?   5   $	??6.5q?5?   5   $
??Left=?5?   5   $??Bottom=?5?   5     ListboxItemFontSize#??[ 5?   5   $
??Bold"?5?   5     ListboxItemForeGroundColor#??[ 5?   5   ??5?   5   ?? $# 	MusicName?$$ TwoWay=?$% PropertyChanged=?5?   5   ?? 5?   2   ' ??Name$' DeleteMusicButton??5?   5   $??2??5?   5   $
??35px??5?   5   $??0,0,4,0q?5?   5   ( ? Cursor$
( Hand??5?   5   $
{?True??5?   5     RegistrationButton#??[ 5?   5     5?   6     5?   :   $! PreviewMouseRightButtonDown??6I   . 5?   >      6T   ?? ) ?? RelativeSource) ?? * ?? Mode$* FindAncestor=?+ ?? AncestorLevel$+ 1??, ?? AncestorType0   *MusicCMS_Admin.Views.UserControls.Music_UC",  $$# DataContext.DeleteMusicCommand?! 6?   ?? $" MusicListbox??$# SelectedItem?5?   ;   .??5?   6   ? .+?5?   :   .	  (MahApps.Metro.IconPacks.PackIconMaterial	  - 	 Name$- CreateArtistKind??5?   =   . 	  Kind$. Delete=?5?   =     RegistrationButtonIcon#??[ 5?   =   5?   7   5?   3   5  /   5  +   5  '   5  #   5
     5     5     5     5     ? 5  
   $??1??6   $??0q?6    5     ?? 5     $??* ?6    .+?5#     ?? -   5        $ Registrationborder??5$     $??0??5%     $??20q?5&     ???#18c274$ 30??5(     ._?5*     ?  5,     ?? 5-     $
??auto ?6(   ?? 5.     $	??10* ?6(   .+?53     ? -   5        / ?Name$/ FormGrid??54     $??1??55     $??20,50,20,10q?56      58     ?? 5:     ?? 5>     ?? 5A     ?? 5E     .+?5J     ?? -   5        $ MusicNameborder??5K     $??0??5L     $??10,10,10,10q?5M     
?????? 
???????$??5q?5P     $ 20??5Q     ._?5T     ?? -   5        $ MusicNameTextbox??5U  !   $??10,5,5,5q?5V  !   $??Center=?5W  !   $
 True??5X  !   $
 True??5Y  !   $
|?True??5Z  !   $??25(?5[  !   $
??Bold"?5\  !   $ False??5]  !   $ 50??5^  !   $ 50??5_  !   #???   5`  !   $ WrapWithOverflow=?5a  !   $ Disabled=?5b  !   5d     ?? 5h     -   5        $ MusicFileborder??5i     $??1??5j     $??10,10,10,10q?5k     
?????? 
???????$??5q?5n     $ 20??5o     ._?5r     ?? $??2??5s  !   $??10q?5t  !   $ ScrollViewer1??5u  !   #???  5v  !   .??5x  "   ?? -	   5        $ MusicFileTextbox??5y  %   $??10,5,5,5q?5z  %   $??Center=?5{  %   $
 True??5|  %   $
 True??5}  %   $
|?True??5~  %   $??25(?5  %   $
??Bold"?5?  %   $ False??5?  %   $	 250??5?  %   $	 250??5?  %   #???   5?  %   $
 Wrap=?5?  %   $ Disabled=?5?  %   5?     5?     ? 5?     -
   5        $/ CreateMusicGrid??5?     $??2??5?     $??10,10,10,10q?5?     .+?5?     ?? -   5        $' CreateMusicButton??5?  !   $
( Hand??5?  !   #??[ 5?  !   ??5?  !   ?? *CreateMusicCommand+.??5?  "   ?  5?  &   ?? 5?  *   $??1* ?6;   ?? 5?  *   $??8* ?6;   .+?5?  &   	  -   5        $- CreateArtistKind??5?  )   $??0??5?  )   $??0,5,7,2q?5?  )   $. Music=?5?  )   #??[ 5?  )   ?? 5?  &   -   5        0 ??Name$!0 CreateArtistButtonTextblock??5?  )   $??1??5?  )   $??20(?5?  )   $
??Bold"?5?  )   $??Create Music??5?  )   5?  #   5?     5?     5?     5?     5?     5?     5?     5?     