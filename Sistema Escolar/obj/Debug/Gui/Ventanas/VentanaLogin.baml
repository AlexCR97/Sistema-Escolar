   M S B A M L   `   `   `  ����I  ESistemaEscolar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:SistemaEscolar.Gui.VentanasSistemaEscolar.Gui.Ventanas  5   	   A%clr-namespace:SistemaEscolar.Gui.UtilSistemaEscolar.Gui.Util  5   	   .    (SistemaEscolar.Gui.Ventanas.VentanaLogin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:SistemaEscolar.Gui.Ventanas     5   	   6util%clr-namespace:SistemaEscolar.Gui.Util     5   	     � Title$  Login��5	   	   $	��720��6   $
��1080��6$    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowState$ 	Maximized=�5   	   .��5      � .+�5   
   �� $��Center=�6   $��Center=�62   .+�5      �� $	��100��6   $	��100��6!   $
��Logo��6.   0   *SistemaEscolar.Gui.Util.CornerRadiusSetter   CornerRadius$ 15��6=   � 5      $	��430��6   $
��0 50q�6    � ColumnDefinitions 5      �� 5      �� 5      �� 5      .+�5      �� -   5         ��Name$ bAdmin��5       �� CornerRadius$ 10��6)   
�������$	��130��6R    �� Padding$ 10q�6^   $��0��6k    � Cursor$
 Hand��6{   ._�5      �� $��Center=�6!   .+�5      �� $��50��6!   $��50��6,   $��0 0 0 10q�68   �� 5      $��Administrador��6$   	 �� TextAlignment$	 Center=�69   5      5       �� 5#      -   5        $ 	bProfesor��5#      $ 10��6,   
�������$	��130��6U   $ 10q�6a   $��1��6n   $
 Hand��6~   ._�5$      �� $��Center=�6!   .+�5%      �� $��50��6!   $��50��6,   $��0 0 0 10q�68   �� 5&      $��Profesor��6$   $	 Center=�64   5'      5(      �� 5+      -   5        $ bAlumno��5+      $ 10��6*   
�������$	��130��6S   $ 10q�6_   $��2��6l   $
 Hand��6|   ._�5,      �� $��Center=�6!   .+�5-      �� $��50��6!   $��50��6,   $��0 0 0 10q�68   �� 5.      $��Alumno��6$   $	 Center=�62   5/      50      51      �� 54      -   5        
 ��Name$
 tbIniciaSesionComo��54      $(��"Inicia sesion como 'Administrador'��64   $	 Center=�6^   $��15(�6u   $��0 0 0 30q�6�   �� 57      -   5         ��Name$ tbMatricula��57      $��	Matricula��6+   $	��300��6<   $��35��6H   $
��10 0q�6T   $��Center=�6c   
�������$ 10��6�   $��0 0 0 10q�6�   �� 58      -   5        $ tbContrasena��58      $��
Contrasena��6,   $	��300��6>   $��35��6J   $
��10 0q�6V   $��Center=�6e   
�������$ 10��6�   $��0 0 0 10q�6�   �� 59      -   5         ��Name$ 	bIngresar��59      $��Ingresar��6(   $	��300��6;   $��35��6G   $ 10��6S   �� 5<      $!��¿Olvidaste tu contraseña?��6   $	 Center=�69   $��0 50 0 0q�6P   $
 Hand��6b   5=      5?      5@      