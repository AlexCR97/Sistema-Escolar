   M S B A M L   `   `   `  ����I  ESistemaEscolar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:SistemaEscolar.Gui.VentanasSistemaEscolar.Gui.Ventanas  5   	   G(clr-namespace:SistemaEscolar.Gui.ModelosSistemaEscolar.Gui.Modelos  5   	   K*clr-namespace:SistemaEscolar.Gui.SeccionesSistemaEscolar.Gui.Secciones  5   	   .    (SistemaEscolar.Gui.Ventanas.VentanaAdmin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:SistemaEscolar.Gui.Ventanas     5   	   <modelos(clr-namespace:SistemaEscolar.Gui.Modelos     5   	   @	secciones*clr-namespace:SistemaEscolar.Gui.Secciones     5   	     � Title$  VentanaAdmin��5
   	   $	��720��6   $
��1080��6+    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�5   	    � 	Resources 5       �� DataType6   0SistemaEscolar.Gui.Modelos.ModeloSeccionCarreras2   ,SistemaEscolar.Gui.Secciones.SeccionCarreras � DataContext6   0SistemaEscolar.Gui.Modelos.ModeloSeccionPersonal2   ,SistemaEscolar.Gui.Secciones.SeccionPersonal5   /SistemaEscolar.Gui.Modelos.ModeloSeccionAlumnos1   +SistemaEscolar.Gui.Secciones.SeccionAlumnos3   -SistemaEscolar.Gui.Modelos.ModeloSeccionAulas/   )SistemaEscolar.Gui.Secciones.SeccionAulas6	   0SistemaEscolar.Gui.Modelos.ModeloSeccionHorarios2
   ,SistemaEscolar.Gui.Secciones.SeccionHorarios6   0SistemaEscolar.Gui.Modelos.ModeloSeccionMaterias2   ,SistemaEscolar.Gui.Secciones.SeccionMaterias��%�  (��       5   8   *, +)(�� \     5   8   *, +)(�� �     5   7   *, +)(��     5   5   *, +)(�� l    5   8   *,	 +)(�� �    5   8   *, +)�� 5   
   seccionCarrerasTemplate��"  68   .R�5         6(   �� 5      �� 5   
   seccionPersonalTemplate��"  68   .R�5         6(   �� 5      �� 5   
   seccionAlumnosTemplate��"  67   .R�5         6'   �� 5      �� 5   
   seccionAulasTemplate��"  65   .R�5         6%   �� 5      �� 5   
   seccionHorariosTemplate��" 	 68   .R�5      
   6(   �� 5      �� 5   
   seccionMateriasTemplate��"  68   .R�5          6(   �� 5!      5"      .��5$      �  � ColumnDefinitions 5%   
   �� 5&      $��* �6   �� 5'      $	��230 �6   .+�5+   
   � $��0��6    � RowDefinitions 5,      �� 5-      $��50 �6    �� 5.      $��* �6    .+�52      ��  �� Padding$ 6q�6   
�������._�53      �� 	 �� Orientation$	 
Horizontal=�6   .+�54      �� $	��100��6   �� 55      -   5        
 ��Name$
 tbNombreSeccion��55       $��Carreras��69   $��Center=�6I   $
��30 0q�6d   56      57      �� 5:      $��1��6   ��6*   �� 5;      �� 5>   
   $��1��6   
�������$��1q�69   ._�5?      �  5@      �� 5A      $	��170 �6$   �� 5B      $��* �6$   �� 5C      $��40 �6$   .+�5G      �� $��0��6   .+�5H      �� $��Profile Image��6   $	��100��65   $	��100��6A   $��	0 30 0 10q�6N   �� 5I      $��Nombre del usuario��6     �� TextAlignment$ Center=�6:   $��0 0 0 20q�6Q   5J      �� 5M      -   5         ��Name$ lvSecciones��5M      $��1��60   ��5N      �� 5O       �� 
TargetType" ��6    .�5P      ��  �� Property � �� �� Value$ Stretch=�6K   �� 5Q       � ��
 ���� 6;   �� 5R       � ��
 �����6<   �� 5S       � ��$ 1q�6@   5T      ��5W      �� 5X      .R�5Y      �� $
 10 8q�6%   ._�5Z   "   �� $	 
Horizontal=�6-   .+�5[   &   �� $��30��6-   $��30��68   �� 5\   &   $��Center=�6A   $��10 0 0 0q�6\   ��60   �� 6\   5]   #   5^      5_      5a      �� 5d      $��2��6   
�������$��1q�69   
�������._�5e      �� $	 
Horizontal=�6!   $��Right=�6:   .+�5f      �� $��25��6!   $��25��6,   $��0 0 10 0q�68   �� 5g      $��25��6!   $��25��6,   $��0 0 10 0q�68   �� 5h      $��25��6!   $��25��6,   $��0 0 10 0q�68   5i      5j      5k      5l      5n      5o      