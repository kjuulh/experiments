import React from "react";
import ReactDOM from "react-dom";
import App from "./App";
import * as serviceWorker from "./serviceWorker";
import { Provider } from "react-redux";
import {
  configureStore,
  createAsyncThunk,
  createSlice,
  PayloadAction,
} from "@reduxjs/toolkit";

const fetchApi = createAsyncThunk<void, void, ApiState>(
  "api/fetch",
  async (_, thunkAPI) => {
    const { currentRequestId, loading } = thunkAPI.getState().api;
  }
);

interface ApiState {
  message: string;
  loading: "idle" | "pending";
  currentRequestId?: string;
  error: string | null;
}

const apiInitialState: ApiState = {
  message: "",
  loading: "idle",
  currentRequestId: undefined,
  error: null,
};

const apiSlice = createSlice({
  name: "api",
  initialState: apiInitialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(fetchApi.pending, (state, action) => {
      if (state.loading === "idle") {
        state.loading = "pending";
        state.currentRequestId = action.meta.requestId;
      }
    });
    builder.addCase(fetchApi.fulfilled, (state, action) => {
      const { requestId } = action.meta;
      if (state.loading === "idle" && state.currentRequestId === requestId) {
        state.loading = "idle";
        state.message = action.payload;
      }
    });
  },
});

const store = configureStore({
  reducer: {},
});

ReactDOM.render(
  <React.StrictMode>
    <Provider store={store}>
      <App />
    </Provider>
  </React.StrictMode>,
  document.getElementById("root")
);

serviceWorker.unregister();
