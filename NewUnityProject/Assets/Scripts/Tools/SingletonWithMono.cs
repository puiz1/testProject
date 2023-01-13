using UnityEngine;
using System.Collections;

public abstract class SingletonWithMono<T> : MonoBehaviour where T: MonoBehaviour{
	private static T m_Instance	=	null;
	
	protected virtual void Awake(){
        //CommonDebug.Log( "Awake:"+m_Instance +" type :"+typeof(T));
        if( m_Instance != null && Component.FindObjectsOfType<T>().Length > 1 ) {
            DestroyImmediate( this.gameObject );
            //CommonDebug.Log( "Destory SingleTon" );
        }
        else {
            m_Instance = GetComponent<T>();
            //CommonDebug.Log( "Allocate Instance : " + m_Instance );
            if( m_Instance.transform.parent == null) DontDestroyOnLoad( this.gameObject );
        }
	}
	
	public static T Instance{
		get{            
            if( m_Instance != null ) {
                return m_Instance;
            }
            else {
                m_Instance = Component.FindObjectOfType<T>();
                if( m_Instance == null ) {
                    //CommonDebug.Log( "=== Create New SingleTone : " + typeof( T ) );
                }
                return m_Instance= m_Instance != null ? m_Instance : new GameObject( typeof( T ).ToString( ), typeof( T ) ).GetComponent<T>( );
            }
		}
	}    

	public virtual void OnApplicationQuit(){		
		m_Instance = null;
        DestroyImmediate( this.gameObject );
	}

    public static bool IsCreate{
        get { return m_Instance != null; }
    }

    public bool IsUseable {
        get {
            return Instance == null ? false : Instance.enabled;
        }
    }
}

