   M S B A M L   `   `   `  ���� L  HEquipo_Futbol_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Equipo_Futbol_GUIEquipo_Futbol_GUI  P LEquipo_Futbol_Negocio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:Equipo_Futbol_Negocio;assembly=Equipo_Futbol_NegocioEquipo_Futbol_Negocio +    %Equipo_Futbol_GUI.AgregarEquipoWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:Equipo_Futbol_GUI     TmodelBclr-namespace:Equipo_Futbol_Negocio;assembly=Equipo_Futbol_Negocio       � Title$  Agregar Equipo��$	��548��$	��800�� � WindowStartupLocation$ CenterOwner=� � DataContext "  Equipo_Futbol_Negocio.Equipo  .��� .+���  �� Padding$ 20q�$��10q�
�������$��1q�._��� .+��� $��22(�$��DemiBold"�$��Agregar Equipo��$��0,0,0,20q�$
��Left=��� $��Nombre del Equipo���� -    ��Name$ txtNombreEquipo��$	��300��$
��Left=�$
��0, 5q� �� 	MaxLength$ 25��   TextBoxErrorTemplate =� ErrorTemplate# [  ���� *NombreEquipo+ �� ValidatesOnExceptions .  �� UpdateSourceTrigger$ PropertyChanged=�.���� $��Cantidad de Jugadores���� -   $ txtCantidadJugadores��$	��300��$
��Left=�$
��0, 5q�# [  ���� *CantidadJugadores+ . $ PropertyChanged=�.���� $"��Nombre del Director Técnico���� -   $ txtNombreDt��$	��300��$
��Left=�$
��0, 5q�$ 30��# [  ���� *
NombreDt+ . $ PropertyChanged=�.���� $��Tipo de Equipo���� -   $ txtTipoEquipo��$	��300��$
��Left=�$
��0, 5q�# [  ���� *
TipoEquipo+ . $ PropertyChanged=�.���� $��Capitán del Equipo���� -   $ txtCapitanEquipo��$	��300��$
��Left=�$
��0, 5q�$ 30��# [  ���� *CapitanEquipo+ . $ PropertyChanged=�.���� $��¿Tiene Sub-21?���� -   	 ��Name$	 chkTieneSub21��$	��400��$
��Left=�$
��0, 5q�
 d� 	IsChecked
 �� *
TieneSub21+$ PropertyChanged=��� -    ��Name$ 
btnGuardar��$��Guardar��$	��400��$
��Left=�$��0, 10q�����  �� 
TargetType" ��.���  �� Property � {� �� Value .   �� Triggers ^�  ^� 
Conditions ��  �� Binding ��  �� ElementName$ txtNombreEquipo�� �� Path$ (Validation.HasError)� �� Value	 False��  �� $ txtCantidadJugadores��$ (Validation.HasError)�	 False��  �� $ txtNombreDt��$ (Validation.HasError)�	 False��  �� $ txtTipoEquipo��$ (Validation.HasError)�	 False��  �� $ txtCapitanEquipo��$ (Validation.HasError)�	 False.0���  � {� . 