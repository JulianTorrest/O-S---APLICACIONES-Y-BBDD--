import streamlit as st
import pandas as pd
import sqlite3

# Conexión a la base de datos
conn = sqlite3.connect('CustomerAccessControl.db')
c = conn.cursor()

# Funciones para interactuar con la base de datos
def get_clients_in_range(start_date, end_date):
    query = "SELECT * FROM clients WHERE entry_date BETWEEN ? AND ?"
    return pd.read_sql(query, conn, params=(start_date, end_date))

def get_top_10_clients():
    query = "SELECT client_id, COUNT(*) as visit_count FROM entries GROUP BY client_id ORDER BY visit_count DESC LIMIT 10"
    return pd.read_sql(query, conn)

def get_clients_not_returned():
    query = "SELECT client_id FROM clients WHERE client_id NOT IN (SELECT client_id FROM entries WHERE entry_date > (SELECT MIN(entry_date) FROM entries))"
    return pd.read_sql(query, conn)

def get_clients_no_consent():
    query = "SELECT * FROM clients WHERE consent = 0"
    return pd.read_sql(query, conn)

def get_client_zones():
    query = "SELECT zone, COUNT(*) as visit_count FROM clients GROUP BY zone ORDER BY visit_count DESC"
    return pd.read_sql(query, conn)

# Interfaz de usuario con Streamlit
st.title('Customer Access Control System')

# Visualización de datos
st.header('Clients who entered the operation center within a date range')
start_date = st.date_input('Start date')
end_date = st.date_input('End date')
clients_in_range = get_clients_in_range(start_date, end_date)
st.write(clients_in_range)

st.header('Top 10 clients with the most entries this month')
top_10_clients = get_top_10_clients()
st.write(top_10_clients)

st.header('Clients who have not returned after their first visit')
clients_not_returned = get_clients_not_returned()
st.write(clients_not_returned)

st.header('Clients who did not authorize data handling')
clients_no_consent = get_clients_no_consent()
st.write(clients_no_consent)

st.header('Zones where clients who entered the operation center this month reside')
client_zones = get_client_zones()
st.write(client_zones)

# Cerrar la conexión a la base de datos
conn.close()
