using UnityEngine;
using System.Collections;
using MySql.Data.MySqlClient;

public class Connection : MonoBehaviour {

    public MySqlParameter par;
    public MySqlCommand command;
    public MySqlDataReader reader;
    MySqlConnection conexao;

    public MySqlConnection Conexao()
    {
         //private string StrConn = "Server= 127.0.0.1; Port=3306; Database=PdC; Uid= root; Pwd=admin";
        try
        {
            string StrConnection = "Server= 127.0.0.1; Port=3306; Database=PdC; User id= root; Password=admin; Pooling = false;";
            conexao = new MySqlConnection(StrConnection);
            conexao.Open();

            return conexao;  
        }
        catch(UnityException e)
        {
            Debug.Log("Erro:" + e);
            return conexao;
        }

    }

    public void FecharConexao()
    {
        if (conexao != null )
        {
                conexao.Close();
                conexao.Dispose();
        }
    }

    public bool Logar(string nickname, string senha)
    {
        Conexao();
        bool logado = false;
        string sql = "select id, nickname, senha from Usuario where nickname= @nickname ";
        command = new MySqlCommand(sql, Conexao());

        par = new MySqlParameter("@nickname", nickname);
        par.MySqlDbType = MySqlDbType.VarChar;
        command.Parameters.Add(par);

        reader = command.ExecuteReader();

        string senhaUsuario;
        if (reader.Read())
        {
            senhaUsuario = reader.GetValue(reader.GetOrdinal("SENHA")).ToString();
            if (senhaUsuario.Equals(senha))
            {
                logado = true;
            }

        }
        FecharConexao();
        return logado;

        

       
       // command = new System.Data.SqlClient.SqlCommand(sql, conexão());
    }
}
