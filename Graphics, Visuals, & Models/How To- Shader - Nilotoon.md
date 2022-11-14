### Initially Set the Materials/Textures

1. Select the _material_ you want to change.
  + Look for a `Materials` folder
2. Find the location of the _Main Texture_ 
  + Look for a `Texture` folder
3. Change the _material_ to `SimpleURPToonLitExample(With Outline)`
4. Set the `_BaseMap (Albedo)` to the _texture_ found in **Step 2**


------------------------------------------------------------------------------


### This section will get rid of shadows on character, but it still looks good

5. Change the _Lighting_
  + Set `_DirectLightMultiplier` to **1**
  + Set `_CelShadeMidPoint` to **-1**
6. Change the _Shadow Mapping_
  + Chage `_ReceiveShadowMappingAmount` to **0** 


------------------------------------------------------------------------------


