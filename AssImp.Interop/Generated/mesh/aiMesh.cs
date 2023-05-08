namespace AssImp.Interop;

public unsafe partial struct aiMesh
{
    [NativeTypeName("unsigned int")]
    public uint mPrimitiveTypes;

    [NativeTypeName("unsigned int")]
    public uint mNumVertices;

    [NativeTypeName("unsigned int")]
    public uint mNumFaces;

    [NativeTypeName("struct aiVector3D *")]
    public aiVector3D* mVertices;

    [NativeTypeName("struct aiVector3D *")]
    public aiVector3D* mNormals;

    [NativeTypeName("struct aiVector3D *")]
    public aiVector3D* mTangents;

    [NativeTypeName("struct aiVector3D *")]
    public aiVector3D* mBitangents;

    [NativeTypeName("struct aiColor4D *[8]")]
    public _mColors_e__FixedBuffer mColors;

    [NativeTypeName("struct aiVector3D *[8]")]
    public _mTextureCoords_e__FixedBuffer mTextureCoords;

    [NativeTypeName("unsigned int[8]")]
    public fixed uint mNumUVComponents[8];

    [NativeTypeName("struct aiFace *")]
    public aiFace* mFaces;

    [NativeTypeName("unsigned int")]
    public uint mNumBones;

    [NativeTypeName("struct aiBone **")]
    public aiBone** mBones;

    [NativeTypeName("unsigned int")]
    public uint mMaterialIndex;

    [NativeTypeName("struct aiString")]
    public aiString mName;

    [NativeTypeName("unsigned int")]
    public uint mNumAnimMeshes;

    [NativeTypeName("struct aiAnimMesh **")]
    public aiAnimMesh** mAnimMeshes;

    [NativeTypeName("unsigned int")]
    public uint mMethod;

    [NativeTypeName("struct aiAABB")]
    public aiAABB mAABB;

    [NativeTypeName("struct aiString **")]
    public aiString** mTextureCoordsNames;

    public unsafe partial struct _mColors_e__FixedBuffer
    {
        public aiColor4D* e0;
        public aiColor4D* e1;
        public aiColor4D* e2;
        public aiColor4D* e3;
        public aiColor4D* e4;
        public aiColor4D* e5;
        public aiColor4D* e6;
        public aiColor4D* e7;

        public ref aiColor4D* this[int index]
        {
            get
            {
                fixed (aiColor4D** pThis = &e0)
                {
                    return ref pThis[index];
                }
            }
        }
    }

    public unsafe partial struct _mTextureCoords_e__FixedBuffer
    {
        public aiVector3D* e0;
        public aiVector3D* e1;
        public aiVector3D* e2;
        public aiVector3D* e3;
        public aiVector3D* e4;
        public aiVector3D* e5;
        public aiVector3D* e6;
        public aiVector3D* e7;

        public ref aiVector3D* this[int index]
        {
            get
            {
                fixed (aiVector3D** pThis = &e0)
                {
                    return ref pThis[index];
                }
            }
        }
    }
}
