package net.elenx.fishmash.activities;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import net.elenx.fishmash.R;
import net.elenx.fishmash.updaters.LoginUpdater;

public class LoginActivity extends OptionsActivity
{
    private EditText editTextLogin;
    private EditText editTextPassword;
    private Button buttonLogIn;

    @Override
    protected void onPostCreate(Bundle savedInstanceState)
    {
        super.onPostCreate(savedInstanceState);
        setContentView(R.layout.actvity_login);

        editTextLogin = (EditText) findViewById(R.id.editTextLogin);
        editTextPassword = (EditText) findViewById(R.id.editTextPassword);
        buttonLogIn = (Button) findViewById(R.id.buttonLogIn);

        buttonLogIn.setOnClickListener
        (
            new View.OnClickListener()
            {
                @Override
                public void onClick(View view)
                {
                    String login = editTextLogin.getText().toString();
                    String password = editTextPassword.getText().toString();

                    new LoginUpdater(me, login, password).execute();
                }
            }
        );
    }
}
