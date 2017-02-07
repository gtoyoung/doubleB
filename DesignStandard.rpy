I-Logix-RPY-Archive version 8.12.0 C++ 9728113
{ IProject 
	- _id = GUID 49723ebf-e2a9-4733-893c-dd56a34f9002;
	- _myState = 8192;
	- _properties = { IPropertyContainer 
		- Subjects = { IRPYRawContainer 
			- size = 3;
			- value = 
			{ IPropertySubject 
				- _Name = "Browser";
				- Metaclasses = { IRPYRawContainer 
					- size = 1;
					- value = 
					{ IPropertyMetaclass 
						- _Name = "Settings";
						- Properties = { IRPYRawContainer 
							- size = 1;
							- value = 
							{ IProperty 
								- _Name = "ShowOrder";
								- _Value = "True";
								- _Type = Bool;
							}
						}
					}
				}
			}
			{ IPropertySubject 
				- _Name = "CG";
				- Metaclasses = { IRPYRawContainer 
					- size = 1;
					- value = 
					{ IPropertyMetaclass 
						- _Name = "Package";
						- Properties = { IRPYRawContainer 
							- size = 2;
							- value = 
							{ IProperty 
								- _Name = "SRID";
								- _Value = "0";
								- _Type = Int;
							}
							{ IProperty 
								- _Name = "SRPID";
								- _Value = "0";
								- _Type = Int;
							}
						}
					}
				}
			}
			{ IPropertySubject 
				- _Name = "ConfigurationManagement";
				- Metaclasses = { IRPYRawContainer 
					- size = 2;
					- value = 
					{ IPropertyMetaclass 
						- _Name = "General";
						- Properties = { IRPYRawContainer 
							- size = 1;
							- value = 
							{ IProperty 
								- _Name = "UseSCCtool";
								- _Value = "Yes";
								- _Type = Enum;
								- _ExtraTypeInfo = "Yes,No";
							}
						}
					}
					{ IPropertyMetaclass 
						- _Name = "SCC";
						- Properties = { IRPYRawContainer 
							- size = 3;
							- value = 
							{ IProperty 
								- _Name = "AuxProjPath";
								- _Value = "File15096";
								- _Type = String;
							}
							{ IProperty 
								- _Name = "ProjName";
								- _Value = "TestFileRepository_\¹\Ý\À\ç\À\º";
								- _Type = String;
							}
							{ IProperty 
								- _Name = "ShowCMStatus";
								- _Value = "True";
								- _Type = Bool;
							}
						}
					}
				}
			}
		}
	}
	- _name = "DesignStandard";
	- _modifiedTimeWeak = 2.3.2017::2:4:19;
	- _lastID = 3;
	- _unitSccProjName = "TestFileRepository_\¹\Ý\À\ç\À\º";
	- _unitSccProjPath = "File15096";
	- _UserColors = { IRPYRawContainer 
		- size = 16;
		- value = 16777215; 16777215; 16777215; 16777215; 16777215; 16777215; 16777215; 16777215; 16777215; 16777215; 16777215; 16777215; 16777215; 16777215; 16777215; 16777215; 
	}
	- _defaultSubsystem = { ISubsystemHandle 
		- _m2Class = "ISubsystem";
		- _filename = "Requirements.sbs";
		- _subsystem = "";
		- _class = "";
		- _name = "Requirements";
		- _id = GUID 8e33ebdf-c83a-43fa-bfb1-202cbe52e492;
	}
	- _component = { IHandle 
		- _m2Class = "IComponent";
		- _filename = "DefaultComponent.cmp";
		- _subsystem = "";
		- _class = "";
		- _name = "DefaultComponent";
		- _id = GUID 3d807bd3-740b-4cd4-b0ee-986e7b89f909;
	}
	- Multiplicities = { IRPYRawContainer 
		- size = 4;
		- value = 
		{ IMultiplicityItem 
			- _name = "1";
			- _count = -1;
		}
		{ IMultiplicityItem 
			- _name = "*";
			- _count = -1;
		}
		{ IMultiplicityItem 
			- _name = "0,1";
			- _count = -1;
		}
		{ IMultiplicityItem 
			- _name = "1..*";
			- _count = -1;
		}
	}
	- Subsystems = { IRPYRawContainer 
		- size = 6;
		- value = 
		{ ISubsystem 
			- fileName = "Requirements";
			- _id = GUID 8e33ebdf-c83a-43fa-bfb1-202cbe52e492;
		}
		{ ISubsystem 
			- fileName = "UseCaseModel";
			- _id = GUID 8cdc52aa-a122-4975-aeaf-f9546a6684ca;
		}
		{ ISubsystem 
			- fileName = "Analysis";
			- _id = GUID 481b8f20-bc57-4d1a-b7c5-85293a721366;
		}
		{ ISubsystem 
			- fileName = "Design";
			- _id = GUID 72d4fe05-71b9-4c5b-b0f9-6406a6ccdcb9;
		}
		{ ISubsystem 
			- fileName = "CustomizedTypes";
			- _id = GUID 92781c37-a3ca-4299-b00b-de178c453366;
		}
		{ ISubsystem 
			- fileName = "GatewayProjectFiles";
			- _id = GUID 0cc4481b-fe81-44cc-be06-fd1de5210771;
		}
	}
	- Diagrams = { IRPYRawContainer 
		- size = 1;
		- value = 
		{ IDiagram 
			- _id = GUID fc55bdee-da82-4265-9e2f-8a837e1c795e;
			- _myState = 8192;
			- _name = "Model1";
			- _modifiedTimeWeak = 1.2.1990::0:0:0;
			- _lastModifiedTime = "11.14.2016::0:1:12";
			- _graphicChart = { CGIClassChart 
				- _id = GUID 73091cc5-9735-493b-955c-badc15d503c0;
				- m_type = 0;
				- m_pModelObject = { IHandle 
					- _m2Class = "IDiagram";
					- _id = GUID fc55bdee-da82-4265-9e2f-8a837e1c795e;
				}
				- m_pParent = ;
				- m_name = { CGIText 
					- m_str = "";
					- m_style = "Arial" 10 0 0 0 1 ;
					- m_color = { IColor 
						- m_fgColor = 0;
						- m_bgColor = 0;
						- m_bgFlag = 0;
					}
					- m_position = 1 0 0  ;
					- m_nIdent = 0;
					- m_bImplicitSetRectPoints = 0;
					- m_nOrientationCtrlPt = 8;
				}
				- m_drawBehavior = 0;
				- m_bIsPreferencesInitialized = 0;
				- elementList = 1;
				{ CGIClass 
					- _id = GUID 26f80bd2-670a-473d-b434-ec8031349504;
					- m_type = 78;
					- m_pModelObject = { IHandle 
						- _m2Class = "IClass";
						- _filename = "Requirements.sbs";
						- _subsystem = "Requirements";
						- _class = "";
						- _name = "TopLevel";
						- _id = GUID 80228137-96e8-44eb-a7fc-1ff3e30f3ad9;
					}
					- m_pParent = ;
					- m_name = { CGIText 
						- m_str = "TopLevel";
						- m_style = "Arial" 10 0 0 0 1 ;
						- m_color = { IColor 
							- m_fgColor = 0;
							- m_bgColor = 0;
							- m_bgFlag = 0;
						}
						- m_position = 1 0 0  ;
						- m_nIdent = 0;
						- m_bImplicitSetRectPoints = 0;
						- m_nOrientationCtrlPt = 5;
					}
					- m_drawBehavior = 0;
					- m_bIsPreferencesInitialized = 0;
					- m_AdditionalLabel = { CGIText 
						- m_str = "";
						- m_style = "Arial" 10 0 0 0 1 ;
						- m_color = { IColor 
							- m_fgColor = 0;
							- m_bgColor = 0;
							- m_bgFlag = 0;
						}
						- m_position = 1 0 0  ;
						- m_nIdent = 0;
						- m_bImplicitSetRectPoints = 0;
						- m_nOrientationCtrlPt = 1;
					}
					- m_polygon = 0 ;
					- m_nNameFormat = 0;
					- m_nIsNameFormat = 0;
					- Compartments = { IRPYRawContainer 
						- size = 2;
						- value = 
						{ CGICompartment 
							- _id = GUID d742dc5f-cf5b-4627-88bd-b91e8177f841;
							- m_name = "Attribute";
							- m_displayOption = Explicit;
							- m_bShowInherited = 0;
							- m_bOrdered = 0;
							- Items = { IRPYRawContainer 
								- size = 0;
							}
						}
						{ CGICompartment 
							- _id = GUID 312f17ba-2d2b-4740-be60-3c5691cbf5aa;
							- m_name = "Operation";
							- m_displayOption = Explicit;
							- m_bShowInherited = 0;
							- m_bOrdered = 0;
							- Items = { IRPYRawContainer 
								- size = 0;
							}
						}
					}
					- Attrs = { IRPYRawContainer 
						- size = 0;
					}
					- Operations = { IRPYRawContainer 
						- size = 0;
					}
				}
				
				- m_access = 'Z';
				- m_modified = 'N';
				- m_fileVersion = "";
				- m_nModifyDate = 0;
				- m_nCreateDate = 0;
				- m_creator = "";
				- m_bScaleWithZoom = 1;
				- m_arrowStyle = 'S';
				- m_pRoot = GUID 26f80bd2-670a-473d-b434-ec8031349504;
				- m_currentLeftTop = 0 0 ;
				- m_currentRightBottom = 0 0 ;
				- m_bFreezeCompartmentContent = 0;
			}
			- _defaultSubsystem = { IHandle 
				- _m2Class = "ISubsystem";
				- _filename = "Requirements.sbs";
				- _subsystem = "";
				- _class = "";
				- _name = "Requirements";
				- _id = GUID 8e33ebdf-c83a-43fa-bfb1-202cbe52e492;
			}
		}
	}
	- Components = { IRPYRawContainer 
		- size = 1;
		- value = 
		{ IComponent 
			- fileName = "DefaultComponent";
			- _id = GUID 3d807bd3-740b-4cd4-b0ee-986e7b89f909;
		}
	}
}

