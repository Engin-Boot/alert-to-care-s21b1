   M S B A M L   `   `   `  ����C  ?Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Frontend.ValidationsFrontend.Validations  5      #clr-namespace:FrontendFrontend  5          Frontend.IcuConfiguration   5      ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >validationrules"clr-namespace:Frontend.Validations     5      (localclr-namespace:Frontend     5      .��5
      ]� $
��True��6   .+�5   
   �� $	��Top=�6   
��� � �$��Add ICU��6<   $��100 100 100 50 q�6K   $��30(�6d   $��Center=�6r   $
��Bold"�6�   6�   �� 5   
   $��Bottom=�6     �� Orientation$  
Horizontal=�6-   $��Center=�6F   $��Center=�6a   $��200 20 200 200q�6~   .+�5      �� -   5         ��Name$ addIcu��5      $	��Add��6&   $��70 30 50 20q�64   $��20(�6I   $��70��6W   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � {� �� Value$ False��66    �� Triggers 5      ^� 5       ^� 
Conditions 5   "   �� 5   &    �� Binding 60   ��  �� Path$ (Validation.HasError)�	 �� ElementName$	 icuId��
 �� Value	
 False6r   �� 5   &    60   �� $ (Validation.HasError)�$	 maxBeds��	
 False6t   �� 5   &    60   �� $ (Validation.HasError)�$	 
LayoutList��	
 False6w   .0�5   "   ��  � {�$
 True��6>   5      5      5      �� 5      -   5        $ cancelButton��5      $��Cancel��6+   $��100 30 50 20q�6<   $��70��6R   $��20(�6]   6�   5       � 5"   
   $��Center=�6   $��Center=�6*    � RowDefinitions 5#      �� 5$      $��80 �6    6.   �� 5%      $��80 �6    6.   �� 5&      $��80 �6    6.    � ColumnDefinitions 5(      �� 5)      $	��180 �6#   61   �� 5*      $	��400 �6#   61   +�5,      �� 5-      $��0��6   $��0��6)   $��Center=�69   $��Enter ICU Id:��6T   $��20(�6i   6y   �� 5.      -   5         ��Name$ icuId��5.   O   $��0��6   $��1��6'   $��40��67   $	��200��6C   $��Center=�6^   $��Center=�6�   $��20(�6�      errorFeedbackStyle#��[  6�   .��6�   ��5/      �� 50      $ IcuId�6#    �� UpdateSourceTrigger$ PropertyChanged=�60    �� ValidatesOnExceptions$
 True��6V    �� NotifyOnValidationError$
 True��6s    �� ValidationRules 51      1   +Frontend.Validations.AddIcuFieldValidations  52   "   ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated$
 True��6I   6k   *   $Frontend.Validations.IcuIdValidation  53   "   6D   55      .��56   $   57      �� 58      $��1��6   $��0��6)   $��Center=�69   $��Max Beds in ICU:��6T   $��20(�6l   6|   �� 59      -   5        $ maxBeds��59   O   $��1��6   $��1��6'   $��40��67   $	��200��6C   $��Center=�6`   $��Center=�6�   $��20(�6�   #��[  6�   .��6�   ��5:      �� 5;      $ MaxBeds�6#   $ PropertyChanged=�62   $
 True��6X   $
 True��6u    5<      0   *Frontend.Validations.MaxBedFieldValidation  5=   "   $
 True��6H   6j   5?      .��5@   $   5A      �� 5B      $��2��6   $��0��6)   $��Center=�69   $��Layout:��6T   $��20(�6d   $
��Left=�6r   6�   �� 5C      -   5         ��Name$ 
LayoutList��5C   8   $��2��6   $��1��6(   $��Center=�6L   $��Center=�6p   $	��200��6�   $��40��6�   $��18(�6�   #��[  6�   ��6�   �� $ 
LayoutList� �� Text 5D      �� 5E      $ Layout�6"   $ PropertyChanged=�60   $
 True��6V   $
 True��6s    5F        5G   "   $
 True��6I   6k   5I      5K      5O      5R      5S      